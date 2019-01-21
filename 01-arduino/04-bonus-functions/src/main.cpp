#include <Arduino.h>

// Creating your own functions

// Topics
// - creating a function: turning a block of code into one line
// - order is important
// - parameters: functions allow for easy variation

const int ledPin = 13;

// no parameters
void blink() {
  const int durationMs = 100;

  digitalWrite(ledPin, HIGH);
  delay(durationMs);
  digitalWrite(ledPin, LOW);
}

// duration parameter
void blinkFor(const int durationMs) {
  digitalWrite(ledPin, HIGH);
  delay(durationMs);
  digitalWrite(ledPin, LOW);
}

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  blink();
  delay(1000);

  // blinkForDemo
  // ------------
  // blinkFor(500);
  // delay(1000);
  // blinkFor(10);
  // delay(1000);
}
