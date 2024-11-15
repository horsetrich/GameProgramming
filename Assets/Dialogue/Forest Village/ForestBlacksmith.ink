-> main

===main===
What do you want?
    +[Buy stuff]
        ->chosen("Ahh just talk to the guy a little ways off, you know what he looks like by now")
    +[Wait... you're familiar...]
        ->chosen("You must've met my brother, Smith")
    +[Nice hammering]
        ->chosen("You hitting on me?")

===chosen(speech)===
{speech}
->END