module Logic

type WonderType = Alexandria | Babylon | Ephesos | Giza | Hali | Olympia | Rhodos
type Side = Day | Night

type Wonder = {
    WonderType: WonderType;
    Side: Side;
}

type Position = Me | Left | Right

type PlayerResult = {
  Wonder: Wonder;
  Position: Position
  Points: int;
}

type Result3Player = PlayerResult array

// TODO: Substitution for database for now
let ExampleResults3Player =
  [
    [|{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};|]
    [|{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};|]
    [|{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};{Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};|]
  ]

let hasLength3 result = Array.length result = 3

let eachWonderTypeIsDifferent (result: Result3Player) =
  result[0].Wonder.WonderType <> result[1].Wonder.WonderType
  && result[0].Wonder.WonderType <> result[2].Wonder.WonderType
  && result[1].Wonder.WonderType <> result[2].Wonder.WonderType

let getPositions result =
  result |> Array.map (fun pr -> pr.Position)

let eachPositionIsDifferent (result: Result3Player) =
  [Me;Left;Right]
  |> List.forall (fun p -> result |> getPositions |> Array.contains p)

let Is3PlayerResultOk result =
  hasLength3 result &&
  eachWonderTypeIsDifferent result &&
  eachPositionIsDifferent result

let Verify3PlayersResults results =
  results
  |> List.filter Is3PlayerResultOk

let GetTheWiner result =
  result
  |> Array.maxBy (fun pr -> pr.Points)