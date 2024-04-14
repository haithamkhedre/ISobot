#include <Isobot.h>

Isobot bot(3);
unsigned long time1, time2,action;

void setup(){
  Serial.begin(9600); 
  time1=time2=millis();
  pinMode(13, OUTPUT);
}

void loop(){
  
  long temp =serReadInt();
  if(temp!=-1)action=temp;
  delay(1000);
     digitalWrite(13,HIGH);
      bot.buttonwrite(action,3);
      digitalWrite(13,LOW);
      delay(3000);

}
 

long serReadInt()
{
 int i, serAva;                           // i is a counter, serAva hold number of serial available
 char inputBytes [7];                 // Array hold input bytes
 char * inputBytesPtr = &inputBytes[0];  // Pointer to the first element of the array
     
 if (Serial.available()>0)            // Check to see if there are any serial input
 {
   delay(5);                              // Delay for terminal to finish transmitted
                                              // 5mS work great for 9600 baud (increase this number for slower baud)
   serAva = Serial.available();  // Read number of input bytes
   for (i=0; i<serAva; i++)       // Load input bytes into array
     inputBytes[i] = Serial.read();
   inputBytes[i] =  '\0';             // Put NULL character at the end
   return atol(inputBytesPtr);    // Call atoi function and return result
 }
 else
   return -1;                           // Return -1 if there is no input
}

