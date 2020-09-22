#define sw1 22
#define sw2 23
#define beep 30
#define I1 2 //Control pin1 Motor A
#define I2 25 //Control pin2 Motor A

#define I3 3 //Control pin1 Motor B
#define I4 27 // //Control pin1 Motor B

int distance;
int current_round;
int motor_power_status = 0;
int one_rev = 1023;
int calibration_offset = 0;
float volt;

void setup() {
  TCCR3B = TCCR3B & B11111000 | B00000001;    // set timer 3 divisor to     1 for PWM frequency of 31372.55 Hz
  //TCCR4B = TCCR4B & B11111000 | B00000010;    // set timer 4 divisor to     8 for PWM frequency of  3921.16 Hz
  pinMode(A0, INPUT); // temporary potentiometer
  pinMode(sw1, INPUT_PULLUP);
  pinMode(sw2, INPUT_PULLUP);//green one
  pinMode(52, OUTPUT); // temporary LED
  pinMode(beep, OUTPUT); //sound

  pinMode(I1, OUTPUT);
  pinMode(I2, OUTPUT);
  pinMode(I3, OUTPUT);
  pinMode(I4, OUTPUT);
  Serial.begin(19200);
}

void loop() {
  volt = analogRead(A0); //read potentiometer

  Calibration(); //calibration process

  Measure_Rotation(volt); //input the volt before mapping
  //chagne the global var "current_round"

  Power_Status_Button(); //ON OFF Motor

  //volt = map(volt, 0, 1023, 0, one_rev);

  distance = current_round * one_rev + volt - calibration_offset;
  distance = map(distance, 0, 1000, 0, 10);

  if (motor_power_status == 1) {
    MotorControl(155);
  }
  else {
    MotorControl(0);
  }

  //display part
//  Serial.print("CR");
//  Serial.print(": ");
//  Serial.print(current_round);
//  Serial.print("  Distance: ");
//  Serial.print(distance);
//  Serial.print("  volt: ");
//  Serial.print(volt);
//  Serial.print("  calibration_offset: ");
//  Serial.print(calibration_offset);
//  Serial.print("  motor_power_status: ");
//  Serial.println(motor_power_status);
  Serial.print(distance);
  Serial.print(",");
  Serial.println(motor_power_status);
}



//function of counting of the rotation
bool trig_pos, trig_neg; //for rotatoin counting

int Measure_Rotation(int x) {
  int thresh_min = 200, thresh_max = 800; //threshold for min and max

  if (x >= thresh_max) {
    trig_pos = true;
  }
  else if (x >= thresh_min && x < thresh_max) {
    trig_pos = false;
  }
  if (x < thresh_min && trig_pos == true) {
    current_round++;
    trig_pos = false;
  }

  if (x <= thresh_min) {
    trig_neg = true;
  }
  else if (x > thresh_min && x <= thresh_max) {
    trig_neg = false;
  }

  if (x > thresh_max && trig_neg == true) {
    current_round--;
    trig_neg = false;
  }

  //do not need to return anything
  //since this function changes global variable "current_round"
}


//function of calibration pressing 2 sec
int button_state;
unsigned long button_millis = 0;
int c_state = 0;

int Calibration() {
  unsigned long current_millis = millis();
  button_state = !digitalRead(sw1);

  if (button_state == 1 && c_state == 0) {
    button_millis = current_millis;
    c_state = 1;
  }

  else if (c_state == 1 && button_state == 0) {
    c_state = 0;
  }

  if (current_millis - button_millis > 1500 && c_state == 1) {
    //calibration goes here

    calibration_offset = volt;
    current_round = 0;
    Calibration_Effect();
    c_state = 0;
  }
}

void Calibration_Effect() {
  digitalWrite(52, 1);
  tone(beep, 1400);
  delay(100);
  noTone(beep);
  digitalWrite(52, 0);
  delay(40);

  digitalWrite(52, 1);
  tone(beep, 1400);
  delay(100);
  noTone(beep);
  digitalWrite(52, 0);

  delay(450);

  digitalWrite(52, 1);
  tone(beep, 1400);
  delay(500);
  noTone(beep);
  digitalWrite(52, 0);
}

void MotorControl(int x) {
  if (x >= 0) {
    analogWrite(I1, x);
    digitalWrite(I2, LOW);
  }

  else {
    analogWrite(I1, 0);
    digitalWrite(I2, LOW);
  }
}

void Power_Status_Button() {
  int sw2_stat = !digitalRead(sw2);
  if (sw2_stat == 1) {
    motor_power_status = (motor_power_status + 1) % 2;
    delay(200);
  }
}
