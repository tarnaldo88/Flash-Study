using FlashStudy.Models;
using SQLite;

namespace FlashStudy.Data;

public static class SeedData
{
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
            new() { DeckId = deck.Id, Front = "What is Big-O notation?", Back = "A way to describe algorithm time/space growth as input size increases.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Time complexity of binary search.", Back = "O(log n) for sorted input.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Time complexity of quicksort (average).", Back = "O(n log n) average, O(n^2) worst-case.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a hash table?", Back = "Key-value store with average O(1) insert/lookup.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Stack vs queue.", Back = "Stack is LIFO; queue is FIFO.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is recursion?", Back = "A function calling itself with smaller subproblems.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define immutability.", Back = "Objects cannot be modified after creation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a pure function?", Back = "No side effects; same input yields same output.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "OOP pillars.", Back = "Encapsulation, inheritance, polymorphism, abstraction.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is dependency injection?", Back = "Providing dependencies from outside a class instead of creating them internally.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is SOLID?", Back = "Five design principles for maintainable OO code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Single Responsibility Principle.", Back = "A class should have one reason to change.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Open/Closed Principle.", Back = "Open for extension, closed for modification.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Liskov Substitution Principle.", Back = "Subtypes should be substitutable for base types.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Interface Segregation Principle.", Back = "Prefer many small interfaces over a large one.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Dependency Inversion Principle.", Back = "Depend on abstractions, not concretions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is unit testing?", Back = "Testing individual units of code in isolation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is integration testing?", Back = "Testing interactions between multiple components.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is TDD?", Back = "Test-driven development: write tests before code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is code review?", Back = "Peer review of code changes for quality and correctness.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CI/CD?", Back = "Automated build/test/deploy pipeline for rapid delivery.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a REST API?", Back = "HTTP-based API using resource-oriented endpoints and verbs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is HTTP status 404?", Back = "Not Found.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is HTTP status 500?", Back = "Internal Server Error.", CreatedAt = now, UpdatedAt = now },
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
            new() { DeckId = deck.Id, Front = "What is an ORM?", Back = "Maps database tables to objects in code.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a feature flag?", Back = "Toggle to enable/disable functionality at runtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a backlog?", Back = "Prioritized list of work items or user stories.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Agile?", Back = "Iterative development emphasizing collaboration and feedback.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a sprint?", Back = "Time-boxed iteration for delivering a set of work.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a user story?", Back = "Short description of a feature from the user's perspective.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a UML diagram?", Back = "Visual model of system components and relationships.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a design pattern?", Back = "Reusable solution to a common software design problem.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Factory pattern?", Back = "Creates objects without exposing creation logic to the client.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Singleton pattern?", Back = "Ensures only one instance of a class exists globally.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Strategy pattern?", Back = "Encapsulates interchangeable behaviors behind a common interface.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Observer pattern?", Back = "Notifies dependent objects when a subject changes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the Adapter pattern?", Back = "Converts one interface into another expected by clients.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is composition over inheritance?", Back = "Prefer composing objects to share behavior instead of subclassing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a DTO?", Back = "Data Transfer Object used to pass data between layers.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a repository pattern?", Back = "Abstraction layer for data access.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an anti-pattern?", Back = "A common but counterproductive solution.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a lambda?", Back = "Anonymous function that can be passed as a value.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a closure?", Back = "Function that captures variables from its enclosing scope.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a null reference exception?", Back = "Error when accessing a member of a null object.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a memory leak?", Back = "Memory no longer needed is not released.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a stack overflow?", Back = "Error when the call stack exceeds its limit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a database transaction?", Back = "Atomic unit of work that commits or rolls back.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "ACID properties.", Back = "Atomicity, Consistency, Isolation, Durability.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is eventual consistency?", Back = "System converges to a consistent state over time.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is optimistic locking?", Back = "Assumes low contention; detects conflicts on commit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is pessimistic locking?", Back = "Locks data to prevent concurrent updates.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a codebase monorepo?", Back = "Single repository containing multiple projects.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a service-level objective (SLO)?", Back = "Reliability target for a service metric.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is technical debt?", Back = "Tradeoff where short-term speed causes future costs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a spike?", Back = "Time-boxed research task to reduce uncertainty.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a retro?", Back = "Team meeting to reflect and improve the process.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a bug triage?", Back = "Prioritizing and assigning bug fixes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is observability?", Back = "Understanding system behavior via logs, metrics, traces.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a distributed trace?", Back = "End-to-end request tracking across services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an SRE?", Back = "Reliability-focused engineer bridging dev and ops.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is infrastructure as code?", Back = "Managing infra with code and version control.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a container?", Back = "Isolated environment packaging app and dependencies.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Kubernetes?", Back = "Orchestrates container deployment, scaling, and management.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a message broker?", Back = "Middleware for routing messages between services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a cron job?", Back = "Scheduled task running at specific times.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a feature branch?", Back = "Isolated branch for a specific change.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Git rebase?", Back = "Moves commits to a new base for a linear history.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is pair programming?", Back = "Two developers collaborate at one workstation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a technical specification?", Back = "Document describing a feature’s design and implementation.", CreatedAt = now, UpdatedAt = now }
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
            new() { DeckId = deck.Id, Front = "Define system design.", Back = "Structuring components, data, and interfaces to meet requirements at scale.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are functional requirements?", Back = "User-visible behaviors the system must provide.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are non-functional requirements?", Back = "Constraints like latency, availability, throughput, security, and cost.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define scalability.", Back = "Ability to handle increasing load by adding resources.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Horizontal vs vertical scaling.", Back = "Horizontal: add machines; vertical: add CPU/RAM to a machine.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is load balancing?", Back = "Distributing traffic across instances to improve availability and throughput.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a reverse proxy?", Back = "Server that receives requests and forwards to internal services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define caching.", Back = "Storing results to serve future requests faster.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Cache aside pattern.", Back = "App checks cache; on miss, fetches from DB and populates cache.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Write-through vs write-back cache.", Back = "Write-through: write cache and DB; write-back: cache first, DB later.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a CDN?", Back = "Distributed edge servers that cache and deliver content close to users.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define replication.", Back = "Keeping multiple copies of data for availability and read scaling.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define sharding.", Back = "Partitioning data across nodes by a shard key.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "CAP theorem.", Back = "In partitions, a system must choose consistency or availability.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Strong vs eventual consistency.", Back = "Strong: reads see latest write; eventual: convergence over time.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is idempotency?", Back = "Multiple identical requests have the same effect as one.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is rate limiting?", Back = "Restricting requests per user/IP/time window to protect services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is backpressure?", Back = "Mechanism to slow producers when consumers are overloaded.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define message queue.", Back = "Buffer that decouples producers and consumers for async processing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "At-least-once vs at-most-once delivery.", Back = "At-least-once may duplicate; at-most-once may lose messages.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a dead letter queue?", Back = "Queue for messages that repeatedly fail processing.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define SLO and SLA.", Back = "SLO: target reliability; SLA: contractual guarantee based on SLOs.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an API gateway?", Back = "Central entry point handling routing, auth, and rate limits.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define observability.", Back = "Ability to understand system state via logs, metrics, and traces.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Blue/green deployment.", Back = "Two environments; switch traffic to the new version for zero downtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Canary release.", Back = "Gradually roll out to a small subset of users before full release.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a circuit breaker?", Back = "Stops calls to a failing service to prevent cascading failures.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define bulkhead isolation.", Back = "Partition resources so failures are contained to a subset.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CQRS?", Back = "Separate read and write models to scale and optimize independently.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is event sourcing?", Back = "Persist state as an append-only log of events.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Monolith vs microservices.", Back = "Monolith: single deployable unit; microservices: independently deployed services.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "When to choose microservices?", Back = "When domain boundaries are clear and independent scaling/deployments are needed.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is service discovery?", Back = "Mechanism for services to find each other dynamically.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a distributed lock?", Back = "Coordination primitive to ensure single ownership across nodes.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Leader election.", Back = "Choosing a single node to coordinate or make decisions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is consistent hashing?", Back = "Key distribution that minimizes remapping when nodes change.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define hot partition.", Back = "A shard receiving disproportionate traffic or data.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Read replicas: tradeoffs.", Back = "Improve reads but add replication lag and consistency challenges.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Multi-region deployment.", Back = "Serve users from multiple regions for latency and resilience.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "RTO vs RPO.", Back = "RTO: max recovery time; RPO: max acceptable data loss.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a schema migration strategy?", Back = "Backward/forward-compatible changes with staged rollouts.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Define P99 latency.", Back = "Latency threshold that 99% of requests complete under.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is tail latency?", Back = "Slowest requests that dominate user experience at high percentiles.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is request hedging?", Back = "Send duplicate requests to reduce tail latency.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is data denormalization?", Back = "Storing redundant data to speed reads at the cost of write complexity.", CreatedAt = now, UpdatedAt = now }
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
            new() { DeckId = deck.Id, Front = "What is C#?", Back = "A modern, object-oriented programming language for the .NET platform.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the CLR?", Back = "The Common Language Runtime that manages execution, GC, and type safety.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CTS?", Back = "Common Type System defines how types are declared and used in .NET.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CLS?", Back = "Common Language Specification ensures language interoperability.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is IL?", Back = "Intermediate Language generated by the compiler before JIT.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is JIT compilation?", Back = "Just-In-Time compilation from IL to machine code at runtime.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is managed code?", Back = "Code executed under CLR control with services like GC.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a namespace?", Back = "A logical grouping to organize types and avoid name collisions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an assembly?", Back = "A compiled .NET unit (DLL/EXE) containing metadata and IL.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Class vs struct.", Back = "Class is reference type; struct is value type.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a record?", Back = "A reference or value type optimized for immutability and value equality.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an interface?", Back = "A contract of members without implementation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an abstract class?", Back = "A base class that cannot be instantiated and may have abstract members.", CreatedAt = now, UpdatedAt = now },
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
            new() { DeckId = deck.Id, Front = "IEnumerable vs IQueryable.", Back = "IEnumerable runs in memory; IQueryable can translate to queries.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "IEnumerable vs IEnumerator.", Back = "IEnumerable produces enumerators; IEnumerator iterates elements.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is LINQ?", Back = "Language Integrated Query for querying collections.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is deferred execution?", Back = "LINQ queries execute when enumerated, not when defined.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a lambda expression?", Back = "An inline anonymous function, e.g., x => x + 1.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an expression tree?", Back = "A data structure representing code as expressions.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a delegate?", Back = "A type-safe reference to a method.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is an event?", Back = "A multicast delegate with restricted invocation.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a multicast delegate?", Back = "A delegate that can invoke multiple methods.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is the event handler pattern?", Back = "Using sender/object and EventArgs to raise events.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "How does try/catch/finally work?", Back = "try executes, catch handles exceptions, finally runs always.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does using statement do?", Back = "Ensures IDisposable is disposed at the end of a scope.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is IDisposable?", Back = "Interface for releasing unmanaged resources via Dispose.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is a finalizer?", Back = "Destructor that runs during GC to clean unmanaged resources.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What are GC generations?", Back = "0, 1, 2 buckets that optimize garbage collection.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is async/await?", Back = "Asynchronous programming model using Tasks.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Task vs ValueTask.", Back = "Task is reference type; ValueTask avoids allocation in some cases.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does ConfigureAwait(false) do?", Back = "Avoids capturing the current sync context.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Why avoid async void?", Back = "Exceptions cannot be awaited and are harder to handle.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is CancellationToken?", Back = "A cooperative way to cancel async operations.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does lock do?", Back = "Synchronizes access to a critical section.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Monitor vs lock.", Back = "lock is syntax sugar over Monitor.Enter/Exit.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What does volatile mean?", Back = "Prevents certain compiler/runtime reordering for a field.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is Interlocked?", Back = "Atomic operations for thread-safe updates.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Thread vs Task.", Back = "Thread is OS thread; Task represents async work.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "Concurrency vs parallelism.", Back = "Concurrency is multiple tasks; parallelism runs at same time.", CreatedAt = now, UpdatedAt = now },
            new() { DeckId = deck.Id, Front = "What is IAsyncEnumerable?", Back = "Async streams for await foreach.", CreatedAt = now, UpdatedAt = now },
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
            new() { DeckId = deck.Id, Front = "DateTime vs DateTimeOffset.", Back = "DateTimeOffset includes offset from UTC.", CreatedAt = now, UpdatedAt = now },
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
