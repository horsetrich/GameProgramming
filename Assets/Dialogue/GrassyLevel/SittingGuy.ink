->main

===main===
Sup, don't forget to pick up coins
    +[Why?]
        ->chosen("Because there's always a shop in every village")
    +[Thanks for the tip!]
        ->chosen("No prob, least I could do")
    +[Why are you here?]
        ->chosen("Playing hooky, don't snitch")
        
===chosen(speech)===
{speech}
->END