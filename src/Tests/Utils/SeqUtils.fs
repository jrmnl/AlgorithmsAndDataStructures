module SeqUtils


let seqEqual fst snd =
    let compare = Seq.compareWith Operators.compare
    compare fst snd = 0