-> main

===main===
Meow!(Hello! Don't forget to hit shift to dash)
    +[I can understand you?!]
        ->chosen("Meow")
    +[I wish I spoke cat]
        ->chosen("Me too")
    +[Anything else you can tell me?]
        ->chosen("Yeah, ghosts don't like light")
        
    ===chosen(speech)===
    {speech}
    ->END