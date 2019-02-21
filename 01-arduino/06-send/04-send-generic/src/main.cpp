#include <Arduino.h>
#include <ArduinoJson.h>

const float ANALOG_MAX = 1023.0f;

const int D2 = 2;
const int D4 = 4;

void setup() {
  Serial.begin(115200);
  while (!Serial) continue;

  pinMode(2, INPUT);
  pinMode(4, INPUT);
  pinMode(7, INPUT);

}

void loop() {
  // create our JSON object
  ArduinoJson::StaticJsonBuffer<200> jsonBuffer;
  ArduinoJson::JsonObject& jsonData = jsonBuffer.createObject();

  // add the analog data
  jsonData["A0"] = 666.6f;

  jsonData["A1"] = 666.6f;
  jsonData["A2"] = 666.6f;
  jsonData["A3"] = 666.6f;
  jsonData["A4"] = 666.6f;
  jsonData["A5"] = 666.6f;

  // add the digital data
  jsonData["D2"] = digitalRead(D2);
  jsonData["D4"] = digitalRead(D4);

  // send the JSON data via serial
  jsonData.printTo(Serial);
  Serial.println();
}
