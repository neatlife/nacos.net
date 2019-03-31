using System.Net;
using System.Reflection;
using Com.Alibaba.Nacos.Exceptions;
using Com.Alibaba.Nacos.Util;
using RestSharp;

namespace Com.Alibaba.Nacos.Request
{
    public abstract class Request
    {
        
        /**
         * 接口地址
         */
        protected string Uri { get; }
        
        /**
         * 接口动词
         */
        protected Method Verb { get; }

        /**
         * 忽略这些属性
         */
        protected string[] StandaloneParameterList = {"uri", "verb"};

        /**
         * 发起请求，做返回值异常检查
         */
        public IRestResponse DoRequest()
        {
            ParameterAndHeader parameterAndHeader = getParameterAndHeader();
            var response = HttpUtil.request(
                    (string) GetType().GetField("Uri", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this),
                    (Method) GetType().GetField("Verb", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this),
                    parameterAndHeader.parameterList,
                    parameterAndHeader.headers
                );
            handleErrorCode((int) response.StatusCode);    
            return response;
        }

        /**
         * 检查异常
         */
        private void handleErrorCode(int code)
        {
	        switch (code)
            {
                case (int) HttpStatusCode.BadRequest:
                    throw new ResponseCodeErrorException(code, "客户端请求中的语法错");
                case (int) HttpStatusCode.Unauthorized:
                    throw new ResponseCodeErrorException(code, "没有权限");
                case (int) HttpStatusCode.NotFound :
                    throw new ResponseCodeErrorException(code, "无法找到资源");
                case (int) HttpStatusCode.InternalServerError:
                    throw new ResponseCodeErrorException(code, "服务器内部错误");
            }
        }
        
        /**
         * 获取请求参数和请求头
         */
        protected abstract ParameterAndHeader getParameterAndHeader();

    }

}
