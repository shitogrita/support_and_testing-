## Applications

### 1. Fibonacci

**Task**: Calculate Fibonacci numbers.

**Usage**:

```bash
# Run the console application
dotnet run --project Fibonacci
```

**Example**:

```
Enter n: 10
Fibonacci F(10) = 55
```

**Debugging Techniques in Visual Studio**:

* **Breakpoint** at the entry of the calculation method (`Fibonacci.Calculate(n)`).
* **Step Into (F11)** to inspect recursive calls.
* **Watch** window to monitor values of variables `n` and `result`.
* **Immediate Window** to evaluate expressions (e.g., `Fibonacci.Calculate(5)`).

### 2. Galaxies

**Task**: Compute distance between two galaxies given their coordinates.

**Usage**:

```bash
# Run the console application
dotnet run --project Galaxies
```

**Example**:

```
Enter coordinates of two galaxies (x1 y1 z1 x2 y2 z2): 0 0 0 1 2 3
Distance = 3.742
```

**Debugging Techniques in Visual Studio**:

* **Breakpoint** in the `CalculateDistance` method.
* **Step Over (F10)** to verify the algorithm without diving into every internal call.
* **Locals and Autos** windows to track input coordinates and computed result.
* **Output Window** combined with `Debug.WriteLine` calls for logging intermediate values.

### 3. Letters

**Task**: Count the number of letters in a string.

**Usage**:

```bash
# Run the console application
dotnet run --project Letters
```

**Example**:

```
Enter a string: Hello World
Number of letters: 10
```

**Debugging Techniques in Visual Studio**:

* **Conditional Breakpoint** (e.g., break when `input.Length > 0`).
* **Tracepoint (Action Breakpoint)** to print values of `input` and `count` to the Output window.
* **Immediate Window** to change the input string on the fly and re-evaluate loops.

---

*All debugging methods above are standard features of Microsoft Visual Studio 2022.*
