﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainParser.Library;
using System.Diagnostics;

namespace DomainParser.Tests
{
    /// <summary>
    /// Summary description for TLDRulesCacheTests
    /// </summary>
    [TestClass]
    public class TLDRulesCacheTests
    {
        public TLDRulesCacheTests()
        {

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetTLDRulesCount()
        {
            //  We should have more than 0 rules loaded.  If we don't, it's probably because
            //  we need to get the rules cache from http://publicsuffix.org/list/ and haven't yet
            //  or the component needs to be configured to look in the correct spot.
            Assert.IsTrue(TLDRulesCache.Instance.TLDRuleLists.Count > 0);
            Assert.IsTrue(TLDRulesCache.Instance.TLDRuleLists.Values.All(list => list.Count > 0));

            Debug.WriteLine(
                string.Format("There are {0} rule lists loaded from the cache.", TLDRulesCache.Instance.TLDRuleLists.Count)
                );

            Debug.WriteLine(
                string.Format("There are {0} rules loaded from the cache.", TLDRulesCache.Instance.TLDRuleLists.Values.Select(list => list.Count).Sum())
                );
        }
    }
}
