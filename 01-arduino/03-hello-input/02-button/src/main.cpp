#include <Arduino.h>

// Reads the state of a button to control an LED

// Topics
// - digitalRead
// - if statement
// - auto type

const int buttonPin = 2;
const int ledPin = 11;

void setup() {
  Serial.begin(9600);

  pinMode(ledPin, OUTPUT);
}

void loop() {
  // hover mouse over buttonState to see type is int
  const auto buttonState = digitalRead(buttonPin); // will be 0 or 1

  int intensity = 0;
  if (buttonState == 0) {
    intensity = 0;
  }
  else {
    intensity = 255;
  }
  analogWrite(ledPin, intensity);

  // alternative ways of thinking about this...
  analogWrite(ledPin, buttonState * 255);
}