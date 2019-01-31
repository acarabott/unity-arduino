#include <Arduino.h>
#include <ArduinoJson.h>

const int ledPin = 11;

void setup() {
  Serial.begin(9600);
  pinMode(ledPin, OUTPUT);
}

void loop() {
  // set up the JSON buffer
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;

  // parse the data: convert from a string to a JsonObject
  ArduinoJson::JsonObject& obj = jsonBuffer.parseObject(Serial);

  // check if parsing was successful
  if (obj.success()) {
    // extract the data we are interested in
    const bool isLedOn = obj["isLedOn"];
    const float ledBrightness = constrain(obj["ledBrightness"], 0.f, 1.f); // never trust input values

    // this is an assignment that is structured like an if statement
    const int ledValue = isLedOn
      ? ledBrightness * 255
      : 0;

    analogWrite(ledPin, ledValue);
  }
}