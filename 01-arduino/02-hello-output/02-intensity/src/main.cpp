#include <Arduino.h>

const int ledPin = 11;

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  int intensity = 10; // change the intensity
  analogWrite(ledPin, intensity);
}