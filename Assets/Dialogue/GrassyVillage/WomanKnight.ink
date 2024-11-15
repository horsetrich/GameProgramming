-> main

===main===
Man I love kicking my feet up by the fire after a hard days work!
    +[It's noon?]
        ->chosen("Hey I don't question your hours")
    +[Looks cozy!]
        ->chosen("Sorry, I have a girlfriend")
    +[Goodbye!]
        ->chosen("Good luck!")
        
===chosen(speech)===
{speech}
->END