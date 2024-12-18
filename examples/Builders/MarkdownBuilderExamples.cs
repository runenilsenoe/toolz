using System;
using Tasks.Builders;

class MarkdownBuilderExamples
{
    static void Main()
    {
        Console.WriteLine("### Example 1: Adding Headings ###");
        Example1();

        Console.WriteLine("\n### Example 2: Adding a Blockquote ###");
        Example2();

        Console.WriteLine("\n### Example 3: Adding a Horizontal Rule ###");
        Example3();

        Console.WriteLine("\n### Example 4: Adding Key-Value Pairs ###");
        Example4();

        Console.WriteLine("\n### Example 5: Creating a Numbered List ###");
        Example5();

        Console.WriteLine("\n### Example 6: Adding a Code Block ###");
        Example6();
    }

    static void Example1()
    {
        string markdown = "";

        // Add a heading with different levels
        markdown = markdown.AddHeading("Main Title", 1)
                           .AddHeading("Subsection", 2);
        
        //Add with the level enum
        markdown = markdown.AddHeading("Subsubsection", HeadingLevel.H3)

        Console.WriteLine(markdown);
        /*
        Output:
        # Main Title

        ## Subsection

        ### Subsubsection

        */
    }

    static void Example2()
    {
        string markdown = "";

        // Add a blockquote
        markdown = markdown.AddBlockquote("This is a blockquote in Markdown.");

        Console.WriteLine(markdown);
        /*
        Output:
        > This is a blockquote in Markdown.
        */
    }

    static void Example3()
    {
        string markdown = "";

        // Add a horizontal rule
        markdown = markdown.AddHorizontalRule();

        Console.WriteLine(markdown);
        /*
        Output:
        ---
        */
    }

    static void Example4()
    {
        string markdown = "";

        // Add key-value pairs
        markdown = markdown.AddKeyValuePair("Author", "John Doe")
                           .AddKeyValuePair("Version", "1.0.0")
                           .AddKeyValuePair("License", "MIT");

        Console.WriteLine(markdown);
        /*
        Output:
        Author: John Doe
        Version: 1.0.0
        License: MIT
        */
    }

    static void Example5()
    {
        string markdown = "";

        // Add a numbered list
        string[] items = { "Install the package", "Configure the settings", "Run the application" };
        markdown = markdown.NewNumberedList(items);

        Console.WriteLine(markdown);
        /*
        Output:
        0. Install the package
        1. Configure the settings
        2. Run the application
        */
    }

    static void Example6()
    {
        string markdown = "";

        // Add a code block with a language
        markdown = markdown.AddCodeBlock(
            "Console.WriteLine(\"Hello, world!\");",
            "csharp"
        );

        Console.WriteLine(markdown);
        /*
        Output:
        ```csharp
        Console.WriteLine("Hello, world!");
        ```
        */
    }
}
