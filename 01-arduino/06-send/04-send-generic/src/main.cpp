#include <Arduino.h>
#include <ArduinoJson.h>

const float ANALOG_MAX = 1023.0f;

const int D2 = 2;
const int D4 = 4;

void setup() {
  Serial.begin(9600);
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
  jsonData["A0"] = analogRead(A0) / ANALOG_MAX;
  jsonData["A1"] = analogRead(A1) / ANALOG_MAX;
  jsonData["A2"] = analogRead(A2) / ANALOG_MAX;
  jsonData["A3"] = analogRead(A3) / ANALOG_MAX;
  jsonData["A4"] = analogRead(A4) / ANALOG_MAX;
  jsonData["A5"] = analogRead(A5) / ANALOG_MAX;

  // add the digital data
  jsonData["D2"] = digitalRead(D2);
  jsonData["D4"] = digitalRead(D4);

  // send the JSON data via serial
  jsonData.printTo(Serial);
  Serial.println();
}
