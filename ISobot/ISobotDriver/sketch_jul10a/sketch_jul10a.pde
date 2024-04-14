#include <Isobot.h>

Isobot bot(3);
long action;

void setup(){
  Serial.begin(9600); 
  pinMode(13, OUTPUT);
}
void blink()
{
    digitalWrite(13,HIGH);
    delay(250);
    digitalWrite(13,LOW);
    delay(250);
}
void loop(){
  
  long temp =serReadInt();
 Serial.println(action);
  if(temp==-1)
  {
     //Serial.println('H');
  }
  else
  {
    blink();
    blink();
    blink();
    action=temp;
    
  }
  
     
     digitalWrite(13,HIGH);
     //Serial.println(action);
     bot.buttonwrite(action,3);
     action=0;
     digitalWrite(13,LOW);
     delay(5000); 

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
   inputBytes[i] =  '\0';      // Put NULL character at the end
   //Serial.println(serAva);
   return atol(inputBytesPtr);    // Call atoi function and return result
 }
 else
 {
   //Serial.println(-1);
   return -1;  
 }   // Return -1 if there is no input
}

