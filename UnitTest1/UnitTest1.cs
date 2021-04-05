using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace IndianStateCensusAnalyserNUnitTestProject
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        static string indianStateCensusFilePath = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFile = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\WrongHeaderIndiaStateCensusData.csv";
        static string IncorrectIndianStateCensusFileName = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\IndiaStateCensusData1.csv";
        static string CorrectIndianStateCensusFileButTypeIncorrect = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\IndiaStateCensusData.txt";
        static string wrongDelimiterIndianCensusFilePath = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\DelimiterIndiaStateCensusData.csv";

        static string indiaStateCodeFilePath = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\IndiaStateCode.csv";
        static string wrongHeaderIndiaStateCodeFile = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\WrongHeaderIndiaStateCode.csv";
        static string IncorrectIndiaStateCodeFileName = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\IndiaStateCode1.csv";
        static string CorrectIndiaStateCodeFileButTypeIncorrect = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\IndiaStateCode.csv";
        static string wrongDelimiterIndiaStateCodeFilePath = @"D:\IndianStateCensusAnaylser\UnitTest1\CSV\DelimiterIndiaStateCode.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]  //TC1.1
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);

        }
        [Test]  //TC1.2
        public void GivenIncorrectIndianCensusDataFileName_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndianStateCensusFileName, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]  //TC1.3
        public void GivenCorrectIndianCensusDataFileName_But_Extension_Incorrect_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CorrectIndianStateCensusFileButTypeIncorrect, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]  //TC1.4
        public void GivenDelimiterInorrectIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]  //TC1.5
        public void GivenWrongHeaderIndianStateCensusData_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFile, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }

        [Test]  //TC2.1
        public void GivenIndianStateCodeFileData_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indiaStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(2, totalRecord.Count);

        }
        [Test]  //TC2.2
        public void GivenIncorrectIndiaStateCodeFileName_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IncorrectIndiaStateCodeFileName, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]  //TC2.3
        public void GivenCorrectIndianStateCodeFileName_But_Extension_Incorrect_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CorrectIndiaStateCodeFileButTypeIncorrect, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]  //TC2.4
        public void GivenDelimiterInorrectIndiaStateCodeFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongDelimiterIndiaStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]  //TC2.5
        public void GivenWrongHeaderIndianStateCode_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndiaStateCodeFile, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }



    }
}