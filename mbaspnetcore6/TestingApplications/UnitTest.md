
# Usnit Testing

1. Understand the Test Case
2. Identitfy The Number of Branching in the Unit (Method / Class / Modules)
    - If a method has if..else Statement, then Minimum Two Unit Tests for Each Block
        - If True
        - If False
        - Else True (Optoinal)
        - Else False (Optional)
3. If a Method Has Exception Handling, then Write a Test for Exceptions
    - Collect the Data that throws an Exception
4. Follow The Brlow Rules for Writing The Unit Test
    - Arrange
        - Process of Collecting required Test Data for Driving the Test
        - The Instance of class of which method to be tested
        - Plan for expected result
        - If there are external Dependencies, make sure that use 'Mocks'
            - Use the Mocks Framework Carefully
    - Act
        - Write a Code for Test
        - Call Method to be Tested and pass test data to the method
        - Grab the Actual result
    - Assertion
        - Evaluate the Expected Result With Actual Result
            - Exact Equal
            - Not Equal, Greate Than, Less Than, Greater-Than-Equal, Less-Than-Equal
            - Object Match
            - Collection Match
            - Object Type Match
            - Deep Object Value Match
            - Exception Match
5. Use the Unit Testing Framework
    - xUnit
        - Generic Unit Testing Workflow
    - NUnit
        - Open-Source and Supported by .NET FOundation
    - Visual Studio MSTest Adapter
        - Bridge between the Source Code to be Tested and the Unit Testing Framework
6. NUnit.Framework;
    - PAckage for Unit Testing
    - TestFixtureAttribute class
        - Applied on the class to inform the Execution ENgine (.NET Runtime) that this class contains Test Cases, so that the .NET Runtime MUST Load the NUnit Framework to Run the Test
    - SetUpAttribute
        -  USed to Define Arrangements (arrange) those are used by all Test Cases in the class
    - TestAttribute
        - Used to Apply on the method that has Test Case Implementation
    - Assert class
        - This is a Heart of UnitTesting Frameworks
        - This is used to Verify the Test
7. DataDriven Test
    - This is used to Read Data from Data Source instead of Hardcoding data in the Method using Arrangement
    - TestCaseAttribute
        - USed to Define Data used for Test
8. Exception Test
    - MUST be checked and verified before checking-In the code in Production    '
    - Assert.Throws<E>(TestDelegate, string, params)
        - E is the Excpetion Type that is expected to be thrown by the method
        - TestDelegate, this will execute the method and list for the exception
        - string, the exception message
        - params: Parameters to be passed 
9. Using the API Testing and Hence the Microservices
    - Understand the Structure of API(?)
        - Find out all external Dependencies
            - Project References
            - Data Access (if any)
                - API may or may not have direct access to database
    - The Project Structure will set following rules for Writing Unit Tests for API Services
        - WHat dependencies are used by API?
        - Which dependencies can be 'MOCKED'?
    - Use the 'Moq' Framework for Mocking the Dependencies
        - This will create a Mock Object in the Memory to execute the test instead of Loading the Dependency object in the Test Application         