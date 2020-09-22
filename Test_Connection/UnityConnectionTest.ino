#define SW 8
#define joy_x A0
#define joy_y A3
#define LEDPin 13

boolean LED = false;
int incomingByte[2];

void setup() {
  Serial.begin(9600);
  pinMode(SW, INPUT_PULLUP);
  pinMode(joy_x, INPUT);
  pinMode(joy_y, INPUT);
  pinMode(LEDPin, OUTPUT);
}

void loop() {
    float joy_rx = analogRead(joy_x); //read the values.
    float joy_ry = analogRead(joy_y);
  
    joy_rx = map(joy_rx, 1, 1024, -50, 50); //reformatting the data for
    joy_ry = map(joy_ry, 1, 1024, -50, 50); //Unity3D script.
  
    Serial.print(joy_rx);
    Serial.print(",");
    Serial.print(joy_ry);
    Serial.print(",");
    Serial.println(!digitalRead(SW));

  if (Serial.available() > 0)
  {
    while (Serial.peek() == 'L') { //Read the value after 'L'
      Serial.read();
      incomingByte[0] = Serial.parseInt();
      if (incomingByte[0] == 1)
      {
        LED = true;
      }
      else {
        LED = false;
      }
    }
    while (Serial.available() > 0) { 
      Serial.read(); //clear the data for next cycle.
    }

  }
  LEDCheck();
}
void LEDCheck() {
  if (LED) {
    digitalWrite(LEDPin, 1);
  }
  else {
    digitalWrite(LEDPin, 0);
  }
  return;
}
