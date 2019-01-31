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
  // auto will use the type that Serial.readString() returns
  // can inspect by hovering the mouse over read, or pressing command k, i
  auto read = Serial.readString();

  // print out the input with the prefix "you said: "
  if (read.length() > 0) {
    String message = "you said: " + read;
    Serial.println(message);

    auto value = read.toInt();
    analogWrite(ledPin, constrain(value, 0, 255));
    Serial.println(value);
  }
}