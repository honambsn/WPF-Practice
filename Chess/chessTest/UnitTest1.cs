using Xunit;  // xUnit testing framework
using System.IO;  // For File operations
using ChessAI.Utilities;  // The namespace of your readPGN class

namespace ChessAI.Tests
{
    public class ReadPGNTests
    {
        // Test for checking that LoadPGNfile correctly loads and parses the file
        [Fact]
        public void LoadPGNFile_ValidFile_ParsesCorrectly()
        {
            // Arrange
            var pgnReader = new readPGN();
            string testFilePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\file.pgn"; // Provide a valid PGN test file path

            // Create a temporary test file (optional, can be done manually too)
            File.WriteAllText(testFilePath, "[Event \"Test Event\"]\n[White \"Player 1\"]\n1. e4 e5");

            // Act
            pgnReader.LoadPGNfile(testFilePath);

            // Assert
            Assert.NotEmpty(pgnReader.GameHeader);  // Check that the header was loaded
            Assert.Contains("Test Event", pgnReader.GameHeader);  // Check a specific part of the header
            Assert.Equal(2, pgnReader.Moves_.Count);  // Check if the correct number of moves were parsed

            // Clean up the test file
            File.Delete(testFilePath);
        }

        // Test for checking that SaveToPGN correctly saves to a file
        [Fact]
        public void SaveToPGN_SavesCorrectly()
        {
            // Arrange
            var pgnReader = new readPGN();
            pgnReader.GameHeader = "[Event \"Test Event\"]\n[White \"Player 1\"]\n";
            pgnReader.Moves_.Add("e4");
            pgnReader.Moves_.Add("e5");

            string outputFilePath = "D:\\Ba Nam\\Own project\\Practice\\c#\\WPF Practice\\Chess\\ChessAI\\Utilities\\output.pgn";

            // Act
            pgnReader.SaveToPGN(outputFilePath);

            // Assert
            Assert.True(File.Exists(outputFilePath));  // Check that the file was created

            // Read the file to check its content
            string fileContent = File.ReadAllText(outputFilePath);
            Assert.Contains("Test Event", fileContent);  // Check the header in the saved file
            Assert.Contains("e4", fileContent);  // Check the move in the saved file

            // Clean up the output file
            File.Delete(outputFilePath);
        }
    }
}
