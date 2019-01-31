#include <Arduino.h> // won't see this with Arduino IDE, but necessary for platform.io

// Explain the basics of an Arduino sketch

// Topics:
// - setup vs loop
// - Serial setup
// - Serial printing

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println("Hello World!");
}

void loop() {
  // put your main code here, to run repeatedly:

  // Uncomment this line to constantly print loop
  // Serial.println("loop");
}