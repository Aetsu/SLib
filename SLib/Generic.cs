using System.Collections.Generic;

namespace SLib
{
    public static class Generic
    {
        public struct SandboxTag
        {
            public string tag;
            public string query;

            public SandboxTag(string tag, string query)
            {
                this.tag = tag;
                this.query = query;
            }
        }


        public struct SandboxRes
        {
            public bool isSandbox;
            public List<SandboxTag> tagList;

            public SandboxRes(bool isSandbox, List<SandboxTag> tagList)
            {
                this.isSandbox = isSandbox;
                this.tagList = tagList;
            }
        }
    }
}
