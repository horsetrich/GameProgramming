-> main

===main===
I'm gonna be late for school!
    +[Oh no!]
        ->chosen("I can't be late again!")
    +[Can I help?]
        ->chosen("No sidequests in this game, I wish")
    +[Good luck!]
        ->chosen("My mom is gonna freak")

===chosen(speech)===
{speech}
->END