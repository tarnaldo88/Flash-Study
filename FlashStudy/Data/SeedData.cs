using FlashStudy.Models;
using SQLite;

namespace FlashStudy.Data;

public static class SeedData
{
    public static async Task EnsureGoDeckAsync(SQLiteAsyncConnection db)
    {
        var existing = await db.Table<Deck>()
            .Where(d => d.Name == "Golang")
            .FirstOrDefaultAsync();

        if (existing is not null)
        {
            return;
        }

        var now = DateTime.UtcNow;
        var deck = new Deck
        {
            Name = "Golang",
            CreatedAt = now,
            UpdatedAt = now
        };

        await db.InsertAsync(deck);

        var cards = new List<Card>
        {
            new() { DeckId = deck.Id, Front = "What is Go?", Back = "A statically typed, compiled language designed for simplicity and concurrency.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Who created Go?", Back = "Robert Griesemer, Rob Pike, and Ken Thompson at Google.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a package in Go?", Back = "A collection of source files in the same directory with the same package name.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the entry point of a Go program?", Back = "The main function in package main.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you declare a variable in Go?", Back = "Use var name type or short declaration name := value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is zero value in Go?", Back = "Default value for uninitialized variables, e.g., 0, false, \"\".", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are Go's basic types?", Back = "bool, string, int/uint, float, complex, byte, rune.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a rune?", Back = "An alias for int32 representing a Unicode code point.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a byte?", Back = "An alias for uint8.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a slice?", Back = "A dynamic view into an array with length and capacity.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Slice length vs capacity.", Back = "Length is number of elements; capacity is max before reallocation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you create a slice?", Back = "Use make([]T, len, cap) or slicing an array.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an array in Go?", Back = "A fixed-size sequence of elements of the same type.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How are arrays passed to functions?", Back = "By value (copied), unless using a pointer or slice.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a map?", Back = "A hash table mapping keys to values.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to check if a key exists in a map?", Back = "Use v, ok := m[key].", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a struct?", Back = "A composite type grouping fields.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you define a method in Go?", Back = "func (r Receiver) Method() {}", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Pointer vs value receiver.", Back = "Pointer receiver can modify the original; value receiver works on a copy.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an interface in Go?", Back = "A set of method signatures that types can implement implicitly.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Does Go have inheritance?", Back = "No; Go uses composition and interfaces.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is embedding in Go?", Back = "Including a type in a struct to promote its methods/fields.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a goroutine?", Back = "A lightweight concurrent function managed by the Go runtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to start a goroutine?", Back = "Prefix a function call with go, e.g., go f().", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a channel?", Back = "A typed conduit for communicating between goroutines.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Buffered vs unbuffered channels.", Back = "Unbuffered blocks until send/receive; buffered allows limited queueing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does closing a channel do?", Back = "Signals no more values will be sent; receivers can range until closed.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to detect a closed channel?", Back = "Use v, ok := <-ch; ok is false when closed.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is select in Go?", Back = "A statement to wait on multiple channel operations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a nil channel behavior?", Back = "Send/receive on nil channel blocks forever.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a race condition?", Back = "When concurrent operations cause nondeterministic results.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to detect race conditions in Go?", Back = "Use the race detector: go test -race.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is sync.Mutex for?", Back = "Mutual exclusion lock for shared data.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is sync.WaitGroup?", Back = "A counter to wait for multiple goroutines to finish.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is sync.Once?", Back = "Ensures a function runs only once.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a context in Go?", Back = "Carries cancellation, deadlines, and request-scoped values.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you cancel a context?", Back = "Use context.WithCancel and call the cancel function.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is defer used for?", Back = "Schedules a function call to run when the surrounding function returns.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is panic?", Back = "A runtime error that stops normal execution and unwinds the stack.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is recover?", Back = "Allows a deferred function to regain control after a panic.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a type assertion?", Back = "Extracts the concrete value from an interface: v := x.(T).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a type switch?", Back = "Switch on dynamic type of an interface value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is error type in Go?", Back = "An interface with Error() string.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you create a custom error?", Back = "Use errors.New or fmt.Errorf, or define a type implementing Error().", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is error wrapping?", Back = "Adding context to errors using fmt.Errorf(\"%w\", err).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to check wrapped errors?", Back = "Use errors.Is or errors.As.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is gofmt?", Back = "The standard Go code formatter.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go build?", Back = "Compiles packages and dependencies.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go test?", Back = "Runs tests in packages.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go mod?", Back = "Module management tool for dependencies.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a Go module?", Back = "A collection of related Go packages with a go.mod file.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does go mod tidy do?", Back = "Adds missing and removes unused module dependencies.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is GOPATH?", Back = "GOPATH (Go Path) is the legacy workspace path for Go projects; less used with modules.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are generics in Go?", Back = "Type parameters enabling reusable, type-safe code (Go 1.18+).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to declare a generic function?", Back = "func F[T any](v T) T { return v }.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the empty interface?", Back = "interface{} that can hold any value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is any?", Back = "Alias for interface{}.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a nil interface pitfall?", Back = "An interface with a typed nil value is not equal to nil.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a pointer in Go?", Back = "A variable holding the address of another value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you allocate with new?", Back = "new(T) returns *T with zero value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you allocate with make?", Back = "make creates slices, maps, and channels.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "make vs new.", Back = "new returns a pointer; make initializes and returns the value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a variadic function?", Back = "A function with ... parameter that accepts variable args.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is named return value?", Back = "Return values declared in function signature.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How does range work on slices?", Back = "Iterates index and value copies for each element.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is shadowing?", Back = "Declaring a variable with same name in inner scope.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is init function?", Back = "A function that runs automatically before main.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is package init order?", Back = "Dependencies init first, then package-level vars, then init funcs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a build tag?", Back = "A directive that includes files based on build constraints.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an interface embedding?", Back = "Combining interfaces by listing them in another interface.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is method set?", Back = "The set of methods a type has for interface satisfaction.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a map zero value?", Back = "nil; read returns zero values; writes panic.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to delete from a map?", Back = "Use delete(m, key).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is JSON marshaling?", Back = "Encoding structs to JSON (JavaScript Object Notation) using encoding/json.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is struct tag in Go?", Back = "Metadata in backticks used by reflection, e.g., json:\"name\".", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How do you read command-line args?", Back = "Use os.Args.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to read environment variables?", Back = "Use os.Getenv or os.LookupEnv.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is net/http used for?", Back = "Building HTTP (Hypertext Transfer Protocol) clients and servers.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to create a basic HTTP server?", Back = "HTTP (Hypertext Transfer Protocol) server: use http.HandleFunc and http.ListenAndServe.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a context deadline?", Back = "A time after which the context is automatically canceled.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go routine leak?", Back = "A goroutine that never completes due to blocked operations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a worker pool?", Back = "A fixed set of goroutines processing jobs from a channel.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is fan-in/fan-out?", Back = "Pattern to merge multiple channels or split work.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is time.After used for?", Back = "Returns a channel that fires after a duration.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a ticker?", Back = "time.Ticker delivers periodic time events on a channel.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is context.WithTimeout?", Back = "Creates a context canceled after a duration.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a pointer receiver needed for?", Back = "To modify the receiver or avoid copying large structs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the blank identifier?", Back = "The underscore _ used to ignore values.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go vet?", Back = "A tool that reports suspicious constructs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the race detector flag?", Back = "Use -race with go test or go run.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go generate?", Back = "Runs code generation commands from //go:generate comments.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is cgo?", Back = "cgo (C Go) is a tool for calling C code from Go.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is build constraint syntax?", Back = "//go:build lines and +build comments.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How to create a test in Go?", Back = "Write functions named TestXxx in *_test.go files.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is benchmarking in Go?", Back = "Use BenchmarkXxx functions in *_test.go and go test -bench.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is table-driven testing?", Back = "Testing multiple cases in a loop with structured data.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go test -run?", Back = "Runs tests matching a regex.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is go test -bench?", Back = "Runs benchmarks matching a regex.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Go's GC?", Back = "GC (Garbage Collector) that manages heap memory concurrently.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is escape analysis?", Back = "Compiler analysis deciding stack vs heap allocation.", CreatedAt = now, UpdatedAt = now }
        };
        await db.InsertAllAsync(cards);
    }
    
    public static async Task EnsureSoftwareEngineerDeckAsync(SQLiteAsyncConnection db)
    {
        var existing = await db.Table<Deck>()
            .Where(d => d.Name == "Software Engineer")
            .FirstOrDefaultAsync();
        
        if (existing is not null)
        {
            return;
        }

        var now = DateTime.UtcNow;
        var deck = new Deck
        {
          Name = "Software Engineer",
          CreatedAt = now,
          UpdatedAt = now  
        };

        await db.InsertAsync(deck);

        var cards = new List<Card>
        {
            new() { DeckId = deck.Id, Front = "What is Big-O notation?", Back = "Big-O (order of growth) describes algorithm time/space growth as input size increases.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Time complexity of binary search.", Back = "O(log n) for sorted input.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Time complexity of quicksort (average).", Back = "O(n log n) average, O(n^2) worst-case.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a hash table?", Back = "Key-value store with average O(1) insert/lookup.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Stack vs queue.", Back = "Stack is LIFO (Last In, First Out); queue is FIFO (First In, First Out).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is recursion?", Back = "A function calling itself with smaller subproblems.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define immutability.", Back = "Objects cannot be modified after creation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a pure function?", Back = "No side effects; same input yields same output.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "OOP pillars.", Back = "OOP (Object-Oriented Programming): encapsulation, inheritance, polymorphism, abstraction.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is dependency injection?", Back = "Providing dependencies from outside a class instead of creating them internally.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is SOLID?", Back = "SOLID (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion) principles for maintainable OO (object-oriented) code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Single Responsibility Principle.", Back = "A class should have one reason to change.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Open/Closed Principle.", Back = "Open for extension, closed for modification.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Liskov Substitution Principle.", Back = "Subtypes should be substitutable for base types.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Interface Segregation Principle.", Back = "Prefer many small interfaces over a large one.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Dependency Inversion Principle.", Back = "Depend on abstractions, not concretions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is unit testing?", Back = "Testing individual units of code in isolation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is integration testing?", Back = "Testing interactions between multiple components.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is TDD?", Back = "TDD (Test-Driven Development): write tests before code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is code review?", Back = "Peer review of code changes for quality and correctness.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CI/CD?", Back = "CI/CD (Continuous Integration/Continuous Delivery) is an automated build/test/deploy pipeline for rapid delivery.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a REST API?", Back = "REST (Representational State Transfer) API (Application Programming Interface) is an HTTP (Hypertext Transfer Protocol) based interface using resource-oriented endpoints and verbs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is HTTP status 404?", Back = "HTTP (Hypertext Transfer Protocol) 404: Not Found.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is HTTP status 500?", Back = "HTTP (Hypertext Transfer Protocol) 500: Internal Server Error.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a race condition?", Back = "Outcome depends on timing of concurrent operations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a deadlock?", Back = "Two or more processes waiting forever on each other.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a mutex?", Back = "A lock to ensure exclusive access to a resource.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an exception?", Back = "An error condition that disrupts normal control flow.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is garbage collection?", Back = "Automatic memory management that reclaims unused objects.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a build artifact?", Back = "Output of the build process, e.g., binaries or packages.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is semantic versioning?", Back = "Versioning scheme: MAJOR.MINOR.PATCH.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a code smell?", Back = "A hint that code may be problematic or need refactoring.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is refactoring?", Back = "Improving code structure without changing behavior.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a database index?", Back = "Data structure that speeds up queries at storage cost.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is normalization?", Back = "Organizing relational data to reduce redundancy.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an ORM?", Back = "ORM (Object-Relational Mapping) maps database tables to objects in code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a feature flag?", Back = "Toggle to enable/disable functionality at runtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a backlog?", Back = "Prioritized list of work items or user stories.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Agile?", Back = "Iterative development emphasizing collaboration and feedback.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a sprint?", Back = "Time-boxed iteration for delivering a set of work.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a user story?", Back = "Short description of a feature from the user's perspective.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a UML diagram?", Back = "UML (Unified Modeling Language) diagram: visual model of system components and relationships.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a design pattern?", Back = "Reusable solution to a common software design problem.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Factory pattern?", Back = "Creates objects without exposing creation logic to the client.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Singleton pattern?", Back = "Ensures only one instance of a class exists globally.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Strategy pattern?", Back = "Encapsulates interchangeable behaviors behind a common interface.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Observer pattern?", Back = "Notifies dependent objects when a subject changes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Adapter pattern?", Back = "Converts one interface into another expected by clients.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is composition over inheritance?", Back = "Prefer composing objects to share behavior instead of subclassing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a DTO?", Back = "DTO (Data Transfer Object) used to pass data between layers.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a repository pattern?", Back = "Abstraction layer for data access.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an anti-pattern?", Back = "A common but counterproductive solution.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a lambda?", Back = "Anonymous function that can be passed as a value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a closure?", Back = "Function that captures variables from its enclosing scope.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a null reference exception?", Back = "Error when accessing a member of a null object.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a memory leak?", Back = "Memory no longer needed is not released.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a stack overflow?", Back = "Error when the call stack exceeds its limit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a database transaction?", Back = "Atomic unit of work that commits or rolls back.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "ACID properties.", Back = "ACID (Atomicity, Consistency, Isolation, Durability).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is eventual consistency?", Back = "System converges to a consistent state over time.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is optimistic locking?", Back = "Assumes low contention; detects conflicts on commit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is pessimistic locking?", Back = "Locks data to prevent concurrent updates.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a codebase monorepo?", Back = "Single repository containing multiple projects.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a service-level objective (SLO)?", Back = "SLO (Service-Level Objective) is the reliability target for a service metric.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is technical debt?", Back = "Tradeoff where short-term speed causes future costs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a spike?", Back = "Time-boxed research task to reduce uncertainty.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a retro?", Back = "Team meeting to reflect and improve the process.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a bug triage?", Back = "Prioritizing and assigning bug fixes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is observability?", Back = "Understanding system behavior via logs, metrics, traces.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a distributed trace?", Back = "End-to-end request tracking across services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an SRE?", Back = "SRE (Site Reliability Engineer) is a reliability-focused engineer bridging dev and ops.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is infrastructure as code?", Back = "Managing infra with code and version control.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a container?", Back = "Isolated environment packaging app and dependencies.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Kubernetes?", Back = "Orchestrates container deployment, scaling, and management.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a message broker?", Back = "Middleware for routing messages between services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a cron job?", Back = "Scheduled task running at specific times.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a feature branch?", Back = "Isolated branch for a specific change.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Git rebase?", Back = "Moves commits to a new base for a linear history.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is pair programming?", Back = "Two developers collaborate at one workstation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a technical specification?", Back = "Document describing a feature’s design and implementation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a linked list?", Back = "A linear collection of nodes where each points to the next.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Array vs linked list tradeoff.", Back = "Arrays have fast indexing; linked lists have cheap inserts/removals.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a binary tree?", Back = "A tree where each node has up to two children.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a binary search tree?", Back = "A binary tree where left < node < right ordering enables fast search.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a heap?", Back = "A tree-based structure with heap-order property; used for priority queues.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a priority queue?", Back = "An ADT (Abstract Data Type) where items are removed by priority, often implemented with a heap.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is breadth-first search (BFS)?", Back = "BFS (Breadth-First Search) is graph traversal visiting neighbors level by level.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is depth-first search (DFS)?", Back = "DFS (Depth-First Search) is graph traversal exploring as far as possible before backtracking.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is dynamic programming?", Back = "Solving problems by combining solutions to overlapping subproblems.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is memoization?", Back = "Caching results of expensive function calls.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a trie?", Back = "Prefix tree for fast string lookups.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a graph?", Back = "A set of vertices connected by edges.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is topological sort used for?", Back = "Ordering nodes in a DAG (Directed Acyclic Graph) based on dependencies.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a DAG?", Back = "DAG (Directed Acyclic Graph) with no cycles.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Dijkstra's algorithm used for?", Back = "Finding shortest paths with non-negative edge weights.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is A* search?", Back = "A* (A-star) is shortest-path search using a heuristic to guide exploration.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a hash collision?", Back = "Different keys map to the same hash bucket.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Open addressing vs chaining.", Back = "Open addressing stores entries in-table; chaining stores lists per bucket.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a load factor?", Back = "Ratio of items to buckets in a hash table.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is amortized analysis?", Back = "Average cost per operation over a sequence of operations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is thread safety?", Back = "Code behaves correctly when accessed concurrently.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a critical section?", Back = "Code that must not be executed by more than one thread at once.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a semaphore?", Back = "A synchronization primitive controlling concurrent access.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a condition variable?", Back = "A mechanism to wait until a condition is signaled.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Process vs thread.", Back = "Processes have separate memory; threads share process memory.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is context switching?", Back = "Saving and restoring CPU (Central Processing Unit) state to switch between threads/processes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is virtual memory?", Back = "Memory abstraction mapping virtual addresses to physical memory.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is paging?", Back = "Managing memory in fixed-size pages for virtual memory.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a memory-mapped file?", Back = "File contents mapped into memory for direct access.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a socket?", Back = "An endpoint for network communication.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "TCP vs UDP.", Back = "TCP (Transmission Control Protocol) is reliable/ordered; UDP (User Datagram Protocol) is faster but unordered/unreliable.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the TCP three-way handshake?", Back = "TCP (Transmission Control Protocol) uses SYN (synchronize), SYN-ACK (synchronize-acknowledge), ACK (acknowledge) to establish a connection.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is DNS?", Back = "DNS (Domain Name System) maps domain names to IP (Internet Protocol) addresses.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an HTTP header?", Back = "HTTP (Hypertext Transfer Protocol) header is metadata sent with a request or response.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is HTTP/2 main benefit?", Back = "HTTP/2 (Hypertext Transfer Protocol 2) multiplexes many requests over a single connection.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is GraphQL?", Back = "GraphQL (graph query language) allows clients to request specific data from APIs (Application Programming Interfaces).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is gRPC?", Back = "gRPC (Remote Procedure Call) framework using Protobuf (Protocol Buffers) and HTTP/2.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "JSON vs Protobuf.", Back = "JSON (JavaScript Object Notation) is human-readable; Protobuf (Protocol Buffers) is compact and faster to parse.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is serialization?", Back = "Converting objects to a storable/transmittable format.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is deserialization?", Back = "Reconstructing objects from a serialized format.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "PUT vs POST.", Back = "PUT (idempotent create/replace) vs POST (create with server-assigned id).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is pagination?", Back = "Splitting results into pages using limit/offset or cursors.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CORS?", Back = "CORS (Cross-Origin Resource Sharing) is a browser security rule controlling cross-origin requests.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is OAuth 2.0?", Back = "OAuth 2.0 (Open Authorization) is an authorization framework for delegated access.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a JWT?", Back = "JWT (JSON Web Token) is a signed JSON (JavaScript Object Notation) token used for claims and authentication.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is TLS?", Back = "TLS (Transport Layer Security) encrypts data in transit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is SQL injection?", Back = "Attack that injects SQL (Structured Query Language) through unsanitized inputs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is XSS?", Back = "XSS (Cross-Site Scripting): injecting scripts into web pages.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CSRF?", Back = "CSRF (Cross-Site Request Forgery) uses a victim's session.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is RBAC?", Back = "RBAC (Role-Based Access Control) for permissions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is SSO?", Back = "SSO (Single Sign-On) across multiple apps.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "CI vs CD.", Back = "CI (Continuous Integration) automates builds/tests; CD (Continuous Delivery) automates delivery or deployment.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is continuous delivery?", Back = "Always in a deployable state with manual release.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is continuous deployment?", Back = "Automatically releasing every change that passes tests.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a rollback?", Back = "Reverting to a previous version after a bad release.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a blue/green deployment?", Back = "Two environments; switch traffic to the new one.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a canary release?", Back = "Rollout to a small percentage of users first.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is code coverage?", Back = "Percentage of code executed by tests.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is mocking?", Back = "Replacing dependencies with test doubles.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Stub vs mock.", Back = "Stubs return data; mocks verify interactions.", CreatedAt = now, UpdatedAt = now }
        };
        await db.InsertAllAsync(cards);
    }
    public static async Task EnsureSystemDesignDeckAsync(SQLiteAsyncConnection db)
    {
        var existing = await db.Table<Deck>()
            .Where(d => d.Name == "System Design")
            .FirstOrDefaultAsync();

        if (existing is not null)
        {
            return;
        }

        var now = DateTime.UtcNow;
        var deck = new Deck
        {
            Name = "System Design",
            CreatedAt = now,
            UpdatedAt = now
        };

        await db.InsertAsync(deck);

        var cards = new List<Card>
        {
            new() { DeckId = deck.Id, Front = "Define system design.", Back = "System design defines the components, data flow, and interfaces of a system. It balances tradeoffs like scalability, reliability, and cost to meet requirements.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are functional requirements?", Back = "Functional requirements describe what the system must do for users. They are expressed as features, behaviors, or API capabilities.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are non-functional requirements?", Back = "Non-functional requirements are constraints on performance and operation, such as latency, availability, throughput, security, and cost. They guide architecture and tradeoffs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define scalability.", Back = "Scalability is the ability to handle increasing load by adding resources without degrading performance. It depends on architecture, data design, and operational strategy.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Horizontal vs vertical scaling.", Back = "Horizontal scaling adds more machines or instances to share load. Vertical scaling increases the power of a single machine (CPU/RAM), which has practical limits.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is load balancing?", Back = "Load balancing distributes incoming requests across instances to improve availability and throughput. It also enables failover by routing around unhealthy nodes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a reverse proxy?", Back = "A reverse proxy sits in front of backend services and forwards client requests to them. It can also handle TLS termination, caching, and routing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define caching.", Back = "Caching stores frequently accessed data so future requests are faster and cheaper. The key challenges are choosing what to cache and when to invalidate.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Cache aside pattern.", Back = "In cache-aside, the application checks the cache first and falls back to the DB on a miss. After fetching, it writes the result to the cache for subsequent requests.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Write-through vs write-back cache.", Back = "Write-through updates cache and DB at the same time for stronger consistency. Write-back updates the cache first and persists to DB later, improving performance but increasing risk.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a CDN?", Back = "A CDN is a geographically distributed network of edge servers that cache content near users. It reduces latency and offloads traffic from the origin.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define replication.", Back = "Replication keeps multiple copies of data across nodes to improve availability and read scaling. It introduces challenges like lag and consistency management.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define sharding.", Back = "Sharding partitions data across nodes using a shard key so each node handles a subset. It improves write and storage scalability but complicates queries and rebalancing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "CAP theorem.", Back = "CAP says that under network partitions, a system must choose between consistency and availability. Real systems decide where to land on this tradeoff based on requirements.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Strong vs eventual consistency.", Back = "Strong consistency means reads always see the latest write. Eventual consistency allows temporary divergence but converges over time, often with higher availability.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is idempotency?", Back = "An idempotent operation can be repeated without changing the result beyond the first application. It is critical for safe retries in distributed systems.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is rate limiting?", Back = "Rate limiting restricts how many requests a user/IP can make in a time window. It protects services from overload and abuse while ensuring fair usage.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is backpressure?", Back = "Backpressure slows producers when consumers are overwhelmed to prevent cascading failures. It keeps queues bounded and stabilizes the system.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define message queue.", Back = "A message queue buffers work so producers and consumers are decoupled in time and scale. It enables async processing and improves resilience.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "At-least-once vs at-most-once delivery.", Back = "At-least-once delivery ensures messages arrive but may create duplicates. At-most-once avoids duplicates but may drop messages, so consumers must choose tradeoffs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a dead letter queue?", Back = "A dead letter queue holds messages that repeatedly fail processing. It enables inspection, alerting, and manual or automated remediation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define SLO and SLA.", Back = "An SLO is the internal reliability target for a service metric. An SLA is the external contractual commitment, often with penalties if the SLO is missed.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an API gateway?", Back = "An API gateway is the centralized entry point for client requests to backend services. It handles routing, authentication, rate limiting, and sometimes aggregation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define observability.", Back = "Observability is the ability to understand a system’s internal state from its outputs. It relies on logs, metrics, and traces to explain behavior and diagnose issues.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Blue/green deployment.", Back = "Blue/green deployment runs two environments so you can switch traffic with minimal downtime. It reduces risk by enabling fast rollback to the previous version.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Canary release.", Back = "A canary release rolls out changes to a small subset of users first. It limits blast radius while you observe real-world behavior before full rollout.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a circuit breaker?", Back = "A circuit breaker stops calls to a failing service after a threshold of errors. It prevents cascading failures and allows recovery before retrying.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define bulkhead isolation.", Back = "Bulkhead isolation partitions resources so failures are contained to a subset of the system. It prevents one overloaded component from taking down others.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CQRS?", Back = "CQRS separates read models from write models to optimize each independently. It is useful when read and write workloads have different performance or scaling needs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is event sourcing?", Back = "Event sourcing persists state as an append-only log of events rather than storing current state directly. You reconstruct state by replaying events, which enables auditability and temporal queries.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Monolith vs microservices.", Back = "A monolith is a single deployable unit with tightly coupled components. Microservices split functionality into independently deployable services with clearer boundaries.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "When to choose microservices?", Back = "Choose microservices when domain boundaries are clear and teams need independent scaling or deployment. The tradeoff is higher operational complexity and distributed coordination.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is service discovery?", Back = "Service discovery lets services find each other dynamically without hardcoding addresses. It is typically backed by a registry and health checks.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a distributed lock?", Back = "A distributed lock ensures single ownership of a resource across multiple nodes. It prevents concurrent conflicting operations but must handle timeouts and failures safely.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Leader election.", Back = "Leader election chooses a single node to coordinate or make decisions in a cluster. It simplifies coordination but requires reliable failure detection.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is consistent hashing?", Back = "Consistent hashing distributes keys across nodes while minimizing remapping when nodes change. It is commonly used for caches and sharded storage.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define hot partition.", Back = "A hot partition is a shard receiving disproportionate traffic or data volume. It can become a bottleneck and often requires rebalancing or key redesign.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Read replicas: tradeoffs.", Back = "Read replicas improve read throughput and reduce load on the primary. They introduce replication lag and consistency challenges for read-after-write use cases.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Multi-region deployment.", Back = "Multi-region deployment serves users from multiple geographic regions for lower latency and resilience. It increases complexity around data consistency and failover.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "RTO vs RPO.", Back = "RTO is the maximum acceptable time to restore service after an outage. RPO is the maximum acceptable data loss, measured as time between backups or replicas.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a schema migration strategy?", Back = "A good migration strategy uses backward- and forward-compatible changes with staged rollouts. It minimizes downtime and allows safe rollback.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define P99 latency.", Back = "P99 latency is the threshold that 99% of requests complete under. It captures tail performance that users notice more than averages.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is tail latency?", Back = "Tail latency refers to the slowest requests at high percentiles like P95 or P99. It can dominate user experience even if the median is fast.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is request hedging?", Back = "Request hedging sends duplicate requests to reduce the impact of slow replicas. It can lower tail latency but increases load and cost.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is data denormalization?", Back = "Denormalization stores redundant data to speed reads. It improves query performance but increases write complexity and risk of inconsistency.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a read-through cache?", Back = "A read-through cache automatically loads data from the backing store on a cache miss. It simplifies application code but can hide slow storage under load.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is write-behind caching?", Back = "Write-behind buffers writes in cache and persists to the DB asynchronously. It improves write latency but risks data loss if the cache fails.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is cache stampede?", Back = "A cache stampede happens when many requests miss simultaneously and overwhelm the DB. Mitigations include request coalescing, locking, or staggered expirations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Cache eviction strategies.", Back = "Common strategies include LRU, LFU, FIFO, and TTL-based eviction. The best choice depends on access patterns and memory constraints.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is read-your-writes consistency?", Back = "Read-your-writes consistency guarantees a client sees its own most recent writes. It is important for user-facing workflows that depend on immediate feedback.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is quorum in distributed systems?", Back = "A quorum is a majority of nodes that must agree for an operation to complete. It balances consistency and availability in replicated systems.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Leader-follower replication.", Back = "In leader-follower replication, the leader handles writes and followers replicate and serve reads. It simplifies conflict handling but can create a write bottleneck.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is log compaction?", Back = "Log compaction removes redundant records while preserving the latest state for each key. It keeps logs smaller without losing essential history.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a write-ahead log?", Back = "A write-ahead log records changes before they are applied to the database. It improves durability and supports recovery after crashes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a two-phase commit?", Back = "Two-phase commit coordinates multiple participants to either all commit or all roll back. It provides atomicity but can be slow and block during failures.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is eventual leader election?", Back = "Eventual leader election means nodes will converge to a single leader after failures or partitions heal. During instability, temporary split leadership can occur.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is split brain?", Back = "Split brain occurs when two nodes both believe they are the leader due to network partition. It can cause conflicting writes and data corruption if not prevented.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a distributed consensus algorithm?", Back = "Distributed consensus algorithms like Raft or Paxos help nodes agree on shared state. They are foundational for leader election and replicated logs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define eventual consistency window.", Back = "The eventual consistency window is the time it takes replicas to converge after a write. Shorter windows improve user experience but often cost more resources.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is read repair?", Back = "Read repair fixes stale replicas during a read by updating out-of-date copies. It improves consistency over time without a separate repair process.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is hinted handoff?", Back = "Hinted handoff temporarily stores writes intended for an unavailable replica. When the replica returns, the stored writes are replayed.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a service mesh?", Back = "A service mesh is an infrastructure layer for service-to-service communication. It typically provides traffic management, security, and observability via sidecars.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is sidecar pattern?", Back = "The sidecar pattern runs a helper process alongside each service instance. It handles cross-cutting concerns like networking, auth, or logging without changing application code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is API rate limiting by token bucket?", Back = "Token bucket rate limiting refills tokens at a steady rate and consumes one per request. It allows short bursts while enforcing a long-term rate.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is leaky bucket rate limiting?", Back = "Leaky bucket queues requests and releases them at a fixed rate. It smooths traffic but can increase latency under bursts.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is autoscaling?", Back = "Autoscaling adjusts instance count based on load or metrics. It improves resilience and cost efficiency when demand fluctuates.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is graceful degradation?", Back = "Graceful degradation reduces non-critical features under load to preserve core functionality. It keeps the system usable during partial failures.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is circuit breaker half-open state?", Back = "The half-open state allows a small number of test requests to probe recovery. If they succeed, the circuit closes; if they fail, it reopens.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a health check?", Back = "A health check is an endpoint used to verify service liveness or readiness. It helps load balancers and orchestrators make routing decisions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Liveness vs readiness probe.", Back = "Liveness probes indicate whether a service should be restarted. Readiness probes indicate whether it can safely receive traffic.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is data partitioning by range?", Back = "Range partitioning shards data by key ranges (e.g., A–F, G–L). It supports efficient range queries but can create hot spots.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is data partitioning by hash?", Back = "Hash partitioning distributes keys evenly across shards by hashing. It balances load but makes range queries harder.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is hot standby?", Back = "A hot standby is a replica kept up to date and ready to take over immediately. It reduces failover time at the cost of extra resources.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is failover?", Back = "Failover is the process of switching to a standby after a primary failure. It aims to minimize downtime and data loss.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a read/write split?", Back = "A read/write split sends writes to the primary and reads to replicas. It improves read scalability but introduces replication lag concerns.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a data lake?", Back = "A data lake is centralized storage for raw structured and unstructured data. It supports flexible analytics but requires strong governance.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a data warehouse?", Back = "A data warehouse is an optimized store for analytics and reporting. It typically contains cleaned, modeled data for BI workloads.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is ETL?", Back = "ETL extracts data from sources, transforms it, and loads it into a target system. It is common in data warehousing pipelines.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Batch vs stream processing.", Back = "Batch processing handles data in periodic jobs, while stream processing handles continuous events. Streaming reduces latency but increases complexity.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is exactly-once processing?", Back = "Exactly-once processing ensures each message affects results only once. It requires careful coordination to avoid duplicates or loss.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is backfill?", Back = "Backfill reprocesses historical data to correct or enrich results. It is often used after bug fixes or schema changes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is schema-on-read?", Back = "Schema-on-read applies structure when data is read rather than when it is written. It provides flexibility but can shift complexity to consumers.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a data retention policy?", Back = "A data retention policy defines how long data is stored before deletion or archival. It balances compliance, cost, and operational needs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is SSO vs federation?", Back = "SSO lets users sign in once across multiple apps. Federation means trusting external identity providers to authenticate users.", CreatedAt = now, UpdatedAt = now }
        };

        await db.InsertAllAsync(cards);
    }

    public static async Task EnsureCSharpDeckAsync(SQLiteAsyncConnection db)
    {
        var existing = await db.Table<Deck>()
            .Where(d => d.Name == "CSharp")
            .FirstOrDefaultAsync();

        if (existing is not null)
        {
            return;
        }

        var now = DateTime.UtcNow;
        var deck = new Deck
        {
            Name = "CSharp",
            CreatedAt = now,
            UpdatedAt = now
        };

        await db.InsertAsync(deck);

        var cards = new List<Card>
        {
            new() { DeckId = deck.Id, Front = "What is C#?", Back = "C# is a modern, object-oriented language designed for the .NET platform. It combines strong typing with productivity features like LINQ and async/await.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the CLR?", Back = "The CLR (Common Language Runtime) executes .NET code and enforces type safety. It also provides services like garbage collection, JIT compilation, and security checks.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CTS?", Back = "The CTS (Common Type System) defines how types are declared and used in .NET. It enables cross-language interoperability by standardizing type rules.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CLS?", Back = "The CLS (Common Language Specification) is a subset of CTS rules that all .NET languages can follow. It ensures libraries are usable across languages.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is IL?", Back = "IL (Intermediate Language) is the CPU-agnostic bytecode produced by the compiler. The CLR later JIT-compiles IL into native machine code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is JIT compilation?", Back = "JIT (Just-In-Time) compilation turns IL into native machine code at runtime. It enables runtime optimizations based on the executing environment.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is managed code?", Back = "Managed code runs under the CLR, which provides services like garbage collection and exception handling. It contrasts with unmanaged code that runs outside the CLR’s control.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a namespace?", Back = "A namespace organizes types into logical groups to avoid name collisions. It also improves readability by signaling ownership or domain.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an assembly?", Back = "An assembly is the compiled unit of deployment in .NET, such as a DLL or EXE. It contains IL, metadata, and versioning information.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Class vs struct.", Back = "Classes are reference types allocated on the heap, while structs are value types typically allocated on the stack. Structs avoid heap allocations but can be costly to copy if large.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a record?", Back = "A record is a type optimized for immutability and value-based equality. It is useful for DTOs and domain models where identity is defined by data.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an interface?", Back = "An interface defines a contract of members without implementation. Types implement interfaces to enable polymorphism and dependency inversion.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an abstract class?", Back = "An abstract class provides shared behavior and can define abstract members. It cannot be instantiated and is meant to be subclassed.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "virtual vs override.", Back = "virtual enables overriding; override provides the derived implementation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a sealed class?", Back = "A class that cannot be inherited.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a partial class?", Back = "A class whose definition is split across multiple files.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a static class?", Back = "A class that cannot be instantiated and only has static members.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an extension method?", Back = "A static method that appears as an instance method on a type.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a property?", Back = "A member that provides get/set access to a field.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an auto-implemented property?", Back = "A property with compiler-generated backing field.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an indexer?", Back = "A property that lets an object be indexed like an array.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a constructor?", Back = "A special method that initializes a new object.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a static constructor?", Back = "A type initializer that runs once before first use.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a readonly field?", Back = "A field that can be assigned only in declaration or constructor.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "const vs readonly.", Back = "const is compile-time constant; readonly is runtime constant.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "ref vs out vs in.", Back = "ref passes by reference, out for output, in for readonly ref.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Value types vs reference types.", Back = "Value types store data directly; reference types store a reference.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is boxing/unboxing?", Back = "Converting value type to object and back.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are nullable reference types?", Back = "Annotations to express nullability for reference types.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are nullable value types?", Back = "Value types that can also be null, like int?.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are generics?", Back = "Type parameters that enable reusable, type-safe code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are generic constraints?", Back = "Restrictions on type parameters, like where T : class.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "IEnumerable vs IQueryable.", Back = "IEnumerable (in-memory enumeration) runs in memory; IQueryable (queryable provider) can translate to queries.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "IEnumerable vs IEnumerator.", Back = "IEnumerable (enumerable interface) produces enumerators; IEnumerator (enumerator interface) iterates elements.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is LINQ?", Back = "Language Integrated Query for querying collections.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is deferred execution?", Back = "LINQ (Language Integrated Query) queries execute when enumerated, not when defined.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a lambda expression?", Back = "An inline anonymous function, e.g., x => x + 1.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an expression tree?", Back = "A data structure representing code as expressions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a delegate?", Back = "A type-safe reference to a method.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an event?", Back = "A multicast delegate with restricted invocation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a multicast delegate?", Back = "A delegate that can invoke multiple methods.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the event handler pattern?", Back = "Using sender/object and EventArgs to raise events.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How does try/catch/finally work?", Back = "try executes, catch handles exceptions, finally runs always.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does using statement do?", Back = "Ensures IDisposable is disposed at the end of a scope.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is IDisposable?", Back = "IDisposable (disposable interface) releases unmanaged resources via Dispose.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a finalizer?", Back = "Destructor that runs during GC (Garbage Collector) to clean unmanaged resources.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are GC generations?", Back = "GC (Garbage Collector) generations 0, 1, 2 are buckets that optimize garbage collection.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is async/await?", Back = "Asynchronous programming model using Tasks.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Task vs ValueTask.", Back = "Task is reference type; ValueTask avoids allocation in some cases.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does ConfigureAwait(false) do?", Back = "Avoids capturing the current sync context.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Why avoid async void?", Back = "Exceptions cannot be awaited and are harder to handle.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CancellationToken?", Back = "A cooperative way to cancel async operations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does lock do?", Back = "Synchronizes access to a critical section.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Monitor vs lock.", Back = "lock is syntax sugar over Monitor.Enter/Exit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does volatile mean?", Back = "Prevents certain compiler/runtime reordering for a field.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Interlocked?", Back = "Atomic operations for thread-safe updates.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Thread vs Task.", Back = "Thread is an OS (Operating System) thread; Task represents async work.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Concurrency vs parallelism.", Back = "Concurrency is multiple tasks; parallelism runs at same time.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is IAsyncEnumerable?", Back = "IAsyncEnumerable (async enumerable) enables async streams for await foreach.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is pattern matching?", Back = "Checking shape/type of data with patterns.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a switch expression?", Back = "An expression-based switch that returns a value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is ?? operator?", Back = "Null-coalescing operator that provides a fallback.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is ?. operator?", Back = "Null-conditional operator for safe member access.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the ! operator for nulls?", Back = "Null-forgiving operator to suppress warnings.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does nameof do?", Back = "Gets the name of a variable, type, or member as a string.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does var mean?", Back = "Implicitly typed local variable.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is dynamic?", Back = "Bypasses compile-time checks and resolves at runtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does 'is' do?", Back = "Type test and pattern matching operator.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a tuple?", Back = "A lightweight grouping of multiple values.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is deconstruction?", Back = "Unpacking values from tuples or types.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "record class vs record struct.", Back = "record class is reference type; record struct is value type.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an init-only setter?", Back = "Allows setting a property only during object creation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the required keyword?", Back = "Forces initialization of properties on object creation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are top-level statements?", Back = "Program entry without explicit Main method.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are global usings?", Back = "Using directives applied to all files in the project.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a file-scoped namespace?", Back = "Namespace declared once per file with semicolon syntax.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a using alias?", Back = "An alias name for a namespace or type.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are attributes?", Back = "Metadata annotations applied to code elements.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is reflection?", Back = "Inspecting types and metadata at runtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is serialization?", Back = "Converting objects to/from text or binary formats.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Span<T>?", Back = "A stack-only view over contiguous memory.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Memory<T>?", Back = "A heap-safe counterpart to Span for async usage.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is StringBuilder for?", Back = "Efficiently building strings with many modifications.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is string interpolation?", Back = "Embedding expressions in strings with $\"{expr}\".", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a verbatim string?", Back = "A string prefixed with @ that ignores escape sequences.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Why are strings immutable?", Back = "For safety, sharing, and performance optimizations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "DateTime vs DateTimeOffset.", Back = "DateTimeOffset includes offset from UTC (Coordinated Universal Time).", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an enum?", Back = "A set of named constants.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a [Flags] enum?", Back = "Enum treated as bit field for combinations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does checked do?", Back = "Enables overflow checking for arithmetic.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does unchecked do?", Back = "Disables overflow checking for arithmetic.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is operator overloading?", Back = "Defining custom behavior for operators on a type.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Implicit vs explicit operators.", Back = "Implicit is automatic; explicit requires a cast.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are index and range?", Back = "Syntax ^ and .. for slicing collections.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are nullable annotations?", Back = "Using ? and ! to express nullability intent.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a with expression?", Back = "Creates a copy of a record with modifications.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a collection initializer?", Back = "Adds items to a collection during creation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an object initializer?", Back = "Sets properties when creating an object.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are property accessors?", Back = "get and set blocks for a property.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are expression-bodied members?", Back = "Members defined using => for single expressions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are tuple element names?", Back = "Named items like (int id, string name).", CreatedAt = now, UpdatedAt = now }
        };

        await db.InsertAllAsync(cards);
    }
}
