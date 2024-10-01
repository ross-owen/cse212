public static class ComplexStack {

    public static void Run()
    {
        var example = "(robot[id + 1].Execute(.Pass()) || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))";
        var result = DoSomethingComplicated(example);
        Console.Out.WriteLine("result = {0}", result);
    }
    // line = "[byu] idaho"
    // line = "[byu) idaho"
    // line = "[]"
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            // item = ']'
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}

// [ * ] == false
// ( * ) == false
// { * } == false

// true


