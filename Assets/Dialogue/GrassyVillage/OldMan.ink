-> main

===main===
Well, good to see you again young lad!
    +[How'd you beat me?]
        ->chosen("Can't be giving all my secrets away now can I?")
    +[Good to see you again!]
        ->chosen("Likewise! I hope to see you again!")
    +[Any more advice?]
        ->chosen("Goodness, young people these days. Always wanting handouts")

===chosen(speech)===
{speech}
->END