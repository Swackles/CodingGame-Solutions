package main

import "fmt"
import "regexp"

func main() {
    var L, S, I, pointer, skip int8
    var file, output string

    fmt.Scan(&L, &S, &I)
    // Setup available memory
    var reservedMemory [100]int16
    var trueMemory = reservedMemory[:S]

    for i := int8(0); i < L; i = i {
        // Get one line of the file
        var line string
        fmt.Scan(&line)

        // Check if line is comment
        var inactiveChars = regexp.MustCompile(`[^<>+-.,\[\]]`)
        if (inactiveChars.ReplaceAllString(line, "") != "") { 
            file += line
            i++
        }
    }

    // Check for sytax error
    var sytaxError = regexp.MustCompile(`[\[\]]`)
    if (len(sytaxError.FindAllStringIndex(file, -1))%2 == 1) {
        fmt.Println("SYNTAX ERROR")
        return
    }

    for i := 0; i < len(file); i = i {
        var command = string(file[i])
        // Skip locig ( [] )
        // Each [ gives +1 to skip which means iteration will go up
        // each ] gives -1 which means iteration will go down
        if (skip != 0) {
            if (skip < 0) { i-- }

            if (command == "]") { skip-- } else if (command == "[") { skip++ }

            // This means the going backwards is done
            if (skip == 0 && command == "[") { i++ }
            continue
        }

        var outPutChar string
        trueMemory[pointer], pointer, skip, outPutChar = PerformCommand(trueMemory[pointer], command, pointer, skip)
        // If there was an output add it to the output list
        if (outPutChar != "") { output += outPutChar}
        // If there is no skip then you can go forwards, if there is skip, go backwards
        if (skip == 0) { i++ } else { i-- }

        // Check for errors
        var errors = CheckForErrors(trueMemory, S, pointer)
        if (errors != "") {
            output = errors
            break
        }
    }

    fmt.Println(output)
}

// Check for other errors and return empty string if no errors occured
func CheckForErrors(memory []int16, S int8, pointer int8) string {
    if (0 > pointer || pointer > S-1) { return "POINTER OUT OF BOUNDS" }
    if (0 > memory[pointer] || memory[pointer] > 255 ) { return "INCORRECT VALUE" }

    return ""
}

// Execute a given command
func PerformCommand(memory int16, command string, pointer int8, skip int8) (int16, int8, int8, string) {
    var output string
    switch command {
    case ">":
        pointer++
    case "<":
        pointer--
	case "+":
		memory++
    case "-":
        memory--
    case ".":
        output = string(memory)
    case ",":
        fmt.Scan(&memory)
    case "[":
        if (memory == 0) { skip++ }
    case "]":
        if (memory != 0) { skip-- }
	}
    return memory, pointer, skip, output
}