#include <Arduino.h>

const int ledPin = 11;

void setup() {
  pinMode(ledPin, OUTPUT);
}

void loop() {
  int intensity = 10; // change the intensity
  analogWrite(ledPin, intensity);

  // fade up
  // int intensity = 0;
  // while(intensity < 255) {
  //   analogWrite(ledPin, intensity);
  //   intensity++;
  //   delay(5);
  // }

  // tasks
  // - reverse fade
  // - fade up then down
}