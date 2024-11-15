-> main

===main===
Oh, hey I guess. I guess I should tell you to right click to attack, but I don't really care
    +[Who are you?]
        ->chosen("I'm a girl? duh?")
    +[Why are you here?]
        ->chosen("This is just my route to school")
    +[Well, good day!]
        ->chosen("Whatever")

===chosen(speech)===
{speech}
->END