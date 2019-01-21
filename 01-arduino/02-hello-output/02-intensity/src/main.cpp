#include <Arduino.h>

// Sets the intensity of an LED

// Topics
// - analogWrite

const int ledPin = 11;

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  int intensity = 10; // change the intensity
  analogWrite(ledPin, intensity);
}