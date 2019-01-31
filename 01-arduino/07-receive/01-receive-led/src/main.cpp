#include <Arduino.h>
#include <ArduinoJson.h>

const int ledPin = 11;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
}

void loop() {
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);
  if (obj.success()) {
    const bool isLedOn = obj["isLedOn"];
    const float ledBrightness = constrain(obj["ledBrightness"], 0.f, 1.f);

    const int ledValue = isLedOn
      ? ledBrightness * 255
      : 0;

    analogWrite(ledPin, ledValue);
  }
}