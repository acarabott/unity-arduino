#include <Arduino.h>
#include <ArduinoJson.h>

const int ledPin = 13;

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);
  if (obj.success()) {
    bool isLedOn = obj["isLedOn"];
    digitalWrite(ledPin, isLedOn);
  }
}