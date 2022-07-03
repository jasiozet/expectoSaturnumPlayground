open Saturn
open Giraffe
open Logic

let app = application {
    use_router (json ExampleResults3Player)
}

run app