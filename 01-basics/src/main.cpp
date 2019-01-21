#include <Arduino.h> // won't see this with Arduino IDE, but necessary for platform.io

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);

  Serial.println("setup");
}

void loop() {
  // put your main code here, to run repeatedly:
  Serial.println("loop");
}