#include <Arduino.h>

const int ledPin = 11;

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  // fade up
  // -------
  // int intensity = 0;
  // while(intensity < 255) {
  //   analogWrite(ledPin, intensity);
  //   intensity += 1; // can use ++
  //   delay(5);
  // }

  // reverse fade
  // ------------

  // while(intensity > 0) {
  //   analogWrite(ledPin, intensity);
  //   intensity -= 1;
  //   delay(5);
  // }

  // fade up then down
  // -----------------
  // while(intensity < 255) {
  //   analogWrite(ledPin, intensity);
  //   intensity += 1;
  //   delay(5);
  // }

  // while(intensity > 0) {
  //   analogWrite(ledPin, intensity);
  //   intensity -= 1;
  //   delay(5);
  // }
}