#include <Arduino.h>

// Read values coming from serial input

// Topics
// - Serial.readString()
// - String concatenation
// - constrain

const int ledPin = 11;


void setup() {
  pinMode(ledPin, OUTPUT);

  Serial.begin(9600);
}

void loop() {
  auto str = Serial.readString();

  if (str.length() > 0) {
    String message = "you said: ";
    message += str;
    Serial.println(message);

    auto value = str.toInt();
    analogWrite(ledPin, constrain(value, 0, 255));
    Serial.println(value);
  }
}