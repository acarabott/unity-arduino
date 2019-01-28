#include <Arduino.h>

// Creating your own functions

// Topics
// - function return values
// - boolean type

const int ledPin = 13;
const int potPin = A0;

const int ANALOG_MAX = 1023;

int half(int value) {
  return value / 2;
}

bool isAboveHalf(int value, int max) {
  return value > half(max);
}

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  const auto potValue = analogRead(potPin);

  if (isAboveHalf(potValue, ANALOG_MAX)) {
    digitalWrite(ledPin, 1);
  }
  else {
    digitalWrite(ledPin, 0);
  }
}
