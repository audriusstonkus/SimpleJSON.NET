﻿using System.Collections.Generic;
using NUnit.Framework;
using SimpleJSON;

namespace Tests.SimpleJSON {
    [TestFixture]
    class JObjectTests {
        [Test]
        public void StringEquality() {
            Assert.AreEqual(JObject.CreateString("test"),
                            JObject.CreateString("test"));
            Assert.AreNotEqual(JObject.CreateString("test"),
                               JObject.CreateString("test2"));
        }

        [Test]
        public void BoolEquality() {
            Assert.AreEqual(JObject.CreateBoolean(true),
                            JObject.CreateBoolean(true));
            Assert.AreNotEqual(JObject.CreateBoolean(true),
                               JObject.CreateBoolean(false));
        }

        [Test]
        public void NullEquality() {
            Assert.AreEqual(JObject.CreateNull(), JObject.CreateNull());
        }

        [Test]
        public void ArrayEquality() {
            Assert.AreEqual(JObject.CreateArray(new List<JObject> { JObject.CreateNull() }),
                            JObject.CreateArray(new List<JObject> { JObject.CreateNull() }));

            Assert.AreNotEqual(JObject.CreateArray(new List<JObject> { JObject.CreateNull() }),
                               JObject.CreateArray(new List<JObject> {
                                                           JObject.CreateNull(),
                                                           JObject.CreateNull()
                                                       }));
        }

        [Test]
        public void ObjectEquality() {
            Assert.AreEqual(JObject.CreateObject(new Dictionary<string, JObject> {
                                                         { "test", JObject.CreateNull() }
                                                     }),
                            JObject.CreateObject(new Dictionary<string, JObject> {
                                                         { "test", JObject.CreateNull() }
                                                     }));

            Assert.AreNotEqual(JObject.CreateObject(new Dictionary<string, JObject> {
                                                            { "test", JObject.CreateNull() }
                                                        }),
                               JObject.CreateObject(new Dictionary<string, JObject> {
                                                            { "test2", JObject.CreateNull() }
                                                        }));
        }

        [Test]
        public void NumberEquality() {
            Assert.AreEqual(JObject.CreateNumber(false, false, false, 100, 0, 0, 0),
                            JObject.CreateNumber(false, false, false, 100, 0, 0, 0));
            Assert.AreEqual(JObject.CreateNumber(true, false, false, 100, 0, 0, 0),
                            JObject.CreateNumber(true, false, false, 100, 0, 0, 0));
            Assert.AreEqual(JObject.CreateNumber(false, true, false, 100, 5, 1, 0),
                            JObject.CreateNumber(false, true, false, 100, 5, 1, 0));
            Assert.AreEqual(JObject.CreateNumber(false, true, false, 100, 5, 1, 2),
                            JObject.CreateNumber(false, true, false, 100, 5, 1, 2));
            Assert.AreEqual(JObject.CreateNumber(true, true, false, 100, 5, 1, 2),
                            JObject.CreateNumber(true, true, false, 100, 5, 1, 2));

            Assert.AreNotEqual(JObject.CreateNumber(true, true, false, 100, 5, 1, 2),
                               JObject.CreateNumber(false, true, false, 100, 5, 1, 2));
        }
    }
}
