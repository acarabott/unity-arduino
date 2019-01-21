#include <Arduino.h>

// Global variable
const int ledPin = 13;

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  // Local variables
  const int onDurationMs = 500;
  const int offDurationMs = 250;

  digitalWrite(ledPin, HIGH);
  delay(onDurationMs);

  digitalWrite(ledPin, LOW);
  delay(offDurationMs);
}