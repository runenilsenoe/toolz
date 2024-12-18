using System;
using Tasks.Builders;

class StringBuilderExamples
{
    static void Main()
    {
        Console.WriteLine("### Example 1: Simple Document ###");
        Example1();

        Console.WriteLine("\n### Example 2: Section with Dashed List ###");
        Example2();

        Console.WriteLine("\n### Example 3: Wrapping Text ###");
        Example3();

        Console.WriteLine("\n### Example 4: Multiple Paragraphs ###");
        Example4();
    }

    static void Example1()
    {
        string document = "";

        // Add a title
        document = StringBuilderExtensions.Title("My Document");

        // Add a paragraph
        document += "This is the first paragraph.".AddParagraph();

        // Add a spacer
        document = document.AddSpacer();

        // Add a list of items
        document = document.NewListPoint("First item")
                           .NewListPoint("Second item")
                           .NewListPoint("Third item");

        Console.WriteLine(document);
        
        /*
        Output:
        My Document

        This is the first paragraph.


        * First item
        * Second item
        * Third item
        */
    }

    static void Example2()
    {
        string section = "";

        // Add a section title
        section = section.AddTextLine("### Features");

        // Add a dashed list
        section = section.NewListDash("Feature 1: String manipulation")
                         .NewListDash("Feature 2: Task timing")
                         .NewListDash("Feature 3: Validation utilities");

        Console.WriteLine(section);
        /*
        Output:
        ### Features
            - Feature 1: String manipulation
            - Feature 2: Task timing
            - Feature 3: Validation utilities
        */
    }

    static void Example3()
    {
        string longText = "This is a very long sentence that needs to be wrapped to fit within a specific width.";

        // Wrap the text to a maximum width of 20 characters
        string wrappedText = longText.WrapText(20);

        Console.WriteLine(wrappedText);
        /*
        Output:
        This is a very long
        sentence that needs
        to be wrapped to fit
        within a specific
        width.
        */
    }

    static void Example4()
    {
        string content = "";

        // Add multiple paragraphs
        content = content.AddTextLine("First paragraph starts here.")
                         .AddParagraph()
                         .AddTextLine("Second paragraph starts here.")
                         .AddParagraph();

        Console.WriteLine(content);
        /*
        Output:
        First paragraph starts here.

        Second paragraph starts here.

        */
    }
}
