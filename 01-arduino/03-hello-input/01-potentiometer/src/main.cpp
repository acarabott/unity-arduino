#include <Arduino.h>

// Reads the value of a potentiometer

// Topics
// - analogRead
// - map

const int potPin = A0;
const int ledPin = 11;

const int inputMax = 1023;
const int outputMax = 255;

void setup() {
  Serial.begin(9600);

  pinMode(ledPin, OUTPUT);
}

void loop() {
  const auto potValue = analogRead(potPin);
  Serial.println(potValue);

  // map the input range to the output range
  const int intensity = map(potValue, 0, inputMax, 0, outputMax);

  // print the value out for debug
  Serial.println(intensity);

  // set the LED
  analogWrite(ledPin, intensity);
}