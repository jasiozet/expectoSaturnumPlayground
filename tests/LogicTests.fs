module Tests

open Expecto
open Logic

[<Tests>]
let tests =
  testList "logic of 3p saving" [
    testCase "3 Player sample result is ok" <| fun _ ->
      let model = [|
          {Wonder = {WonderType=Alexandria;Side=Day}; Points=51; Position=Left};
          {Wonder = {WonderType=Babylon;Side=Day}; Points=51; Position=Right};
          {Wonder = {WonderType=Ephesos;Side=Day}; Points=51; Position=Me};
      |]
      Expect.isTrue (Is3PlayerResultOk model) "ok"

    testCase "3 Player sample result is wrong because it has same wonder" <| fun _ ->
      let model = [|
          {Wonder = {WonderType=Alexandria;Side=Day}; Points=51; Position=Left};
          {Wonder = {WonderType=Babylon;Side=Day}; Points=51; Position=Right};
          {Wonder = {WonderType=Alexandria;Side=Night}; Points=51; Position=Me};
      |]
      Expect.isFalse (Is3PlayerResultOk model) "ok"

    testCase "3 Player sample result is wrong because it has same position" <| fun _ ->
      let model = [|
          {Wonder = {WonderType=Alexandria;Side=Day}; Points=51; Position=Me};
          {Wonder = {WonderType=Babylon;Side=Day}; Points=51; Position=Right};
          {Wonder = {WonderType=Ephesos;Side=Day}; Points=51; Position=Me};
      |]
      Expect.isFalse (Is3PlayerResultOk model) "ok"

    testCase "3 Player sample result is wrong because it has only 1 result" <| fun _ ->
      let model = [|
          {Wonder = {WonderType=Alexandria;Side=Day}; Points=51; Position=Me};
      |]
      Expect.isFalse (Is3PlayerResultOk model) "ok"

    testCase "3 Player sample result is wrong because it has 4 results" <| fun _ ->
      let model = [|
          {Wonder = {WonderType=Alexandria;Side=Day}; Points=51; Position=Left};
          {Wonder = {WonderType=Babylon;Side=Day}; Points=51; Position=Right};
          {Wonder = {WonderType=Ephesos;Side=Day}; Points=51; Position=Me};
          {Wonder = {WonderType=Giza;Side=Day}; Points=51; Position=Me};
      |]
      Expect.isFalse (Is3PlayerResultOk model) "ok"
  ]
