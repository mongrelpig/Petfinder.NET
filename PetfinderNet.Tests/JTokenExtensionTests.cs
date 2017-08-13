using Xunit;
using Newtonsoft.Json.Linq;
using PetfinderNet.Extensions;

namespace PetfinderNet.Tests
{
    public class JTokenExtensionTests
    {
        private readonly JObject _testObject;
        
        public JTokenExtensionTests()
        {
            _testObject = new JObject
            {
                {"rootToken", "root"},
                {"object", new JObject
                    {
                        {"nestedToken", "1"}
                    }
                },
                {"array", new JArray
                    {
                        "item1",
                        "item2",
                        "item3"
                    }
                },
                {"ambiguousToken", new JObject
                    {
                        {"singleItem", "2"}
                    }
                },
                {"ambiguousToken2", new JArray
                    {
                        new JObject{{"item1", "3"}},
                        new JObject{{"item2", "4"}}
                    }
                }
            };
        }
        
        
        [Fact]
        public void ShouldFindToken()
        {
            var token = _testObject.FindToken("rootToken");
            Assert.NotNull(token);
            Assert.Equal("root", token.Value<string>());
        }

        [Fact]
        public void ShouldFindNestedToken()
        {
            var token = _testObject.FindToken("object", "nestedToken");
            Assert.NotNull(token);
            Assert.Equal("1", token.Value<string>());
        }

        [Fact]
        public void ShouldNotFindToken()
        {
            var token = _testObject.FindToken("non", "existent");
            Assert.Null(token);
        }
        
        [Fact]
        public void ShouldFindValue()
        {
            var value = _testObject.FindValue<string>("rootToken");
            Assert.NotNull(value);
            Assert.Equal("root", value);
        }

        [Fact]
        public void ShouldFindObject()
        {
            var obj = _testObject.FindObject("object");
            Assert.NotNull(obj);
            Assert.Equal("1", obj["nestedToken"]);
        }
        
        [Fact]
        public void ShouldFindList()
        {
            var list = _testObject.FindList("ambiguousToken2");
            Assert.NotNull(list);
            Assert.Equal(2, list.Count);
            Assert.Equal("3", list[0]["item1"]);
            Assert.Equal("4", list[1]["item2"]);
        }

        [Fact]
        public void ShouldFindSingleItemList()
        {
            var singleItem = _testObject.FindList("ambiguousToken");
            Assert.NotNull(singleItem);
            Assert.Equal(1, singleItem.Count);
            Assert.Equal("2", singleItem[0]["singleItem"]);
        }

        [Fact]
        public void ShouldFindArray()
        {
            var array = _testObject.FindArray("array");
            Assert.NotNull(array);
            Assert.Equal(3, array.Count);
            Assert.Equal("item1", array[0]);
            Assert.Equal("item2", array[1]);
            Assert.Equal("item3", array[2]);
        }
    }
}