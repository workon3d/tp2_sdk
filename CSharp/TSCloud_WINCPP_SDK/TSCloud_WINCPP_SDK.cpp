// This is the main DLL file.

#include "stdafx.h"

#include "TSCloud_WINCPP_SDK.h"
#include "json.h"


namespace TDSPRINT{
	namespace Cloud{ 
		namespace WINCPP_SDK {

			BaseAPICore::BaseAPICore()
			{
				m_TSCloud = gcnew TDSPRINT::Cloud::SDK::TSCloud();
			}

			BaseAPICore::BaseAPICore(const std::wstring& host)
			{
				m_TSCloud = gcnew TDSPRINT::Cloud::SDK::TSCloud();
				if (!host.empty())
					m_TSCloud->TcHost = StringConverter::nativeToManaged(host);
			}

			std::wstring BaseAPICore::authenticate(std::wstring Email, std::wstring Password)
			{
				msclr::auto_gcroot<TDSPRINT::Cloud::SDK::Datas::User^> user = m_TSCloud->authenticate(
					StringConverter::nativeToManaged(Email),
					StringConverter::nativeToManaged(Password));

				if (user->api_token && user->api_token->Length != 0) {
					Json::Value result;
					result["id"] = user->GetId();
					result["api_token"] = StringConverter::ws2s(StringConverter::managedToNative(user->api_token));
					result["email"] = StringConverter::ws2s(StringConverter::managedToNative(user->email));

					Json::FastWriter writer;
					std::string s = writer.write(result);
					return StringConverter::s2ws(s);
				}
	
				return std::wstring(L"{}");
			}

			/////////////////////
			PrinterAPICore::PrinterAPICore()
			{
				m_tp2 = gcnew TDSPRINT::Cloud::SDK::PrinterClient();
			}

			PrinterAPICore::PrinterAPICore(const std::wstring& host)
			{
				m_tp2 = gcnew TDSPRINT::Cloud::SDK::PrinterClient();
				if (!host.empty())
					m_tp2->TcHost = StringConverter::nativeToManaged(host);
			}

			std::wstring PrinterAPICore::authenticate(std::wstring Email, std::wstring Password)
			{
				msclr::auto_gcroot<TDSPRINT::Cloud::SDK::Datas::User^> user = m_tp2->authenticate(
					StringConverter::nativeToManaged(Email),
					StringConverter::nativeToManaged(Password));

				if (user->api_token && user->api_token->Length != 0) {
					Json::Value result;
					result["id"] = user->GetId();
					result["api_token"] = StringConverter::ws2s(StringConverter::managedToNative(user->api_token));
					result["email"] = StringConverter::ws2s(StringConverter::managedToNative(user->email));

					Json::FastWriter writer;
					std::string s = writer.write(result);
					return StringConverter::s2ws(s);
				}
	
				return std::wstring(L"{}");
			}

			std::wstring PrinterAPICore::authenticate(std::wstring ApiToken)
			{
				msclr::auto_gcroot<TDSPRINT::Cloud::SDK::Datas::User^> user = m_tp2->authenticate(StringConverter::nativeToManaged(ApiToken));

				if (user->api_token && user->api_token->Length != 0) {
					Json::Value result;
					result["id"] = user->GetId();
					result["api_token"] = StringConverter::ws2s(StringConverter::managedToNative(user->api_token));
					result["email"] = StringConverter::ws2s(StringConverter::managedToNative(user->email));

					Json::FastWriter writer;
					std::string s = writer.write(result);
					return StringConverter::s2ws(s);
				}
	
				return std::wstring(L"{}");
			}

			bool PrinterAPICore::Create(std::wstring PrinterName, std::wstring MetaJson)
			{
				msclr::auto_gcroot<TDSPRINT::Cloud::SDK::Datas::Printer^> printer = m_tp2->Create(
					StringConverter::nativeToManaged(PrinterName), 
					StringConverter::nativeToManaged(MetaJson));
				return ((int)(printer->StatusCode) == 200/*HttpStatusCode::OK*/) ? true : false;
			}

			void PrinterAPICore::CreateAsync(std::wstring PrinterName, std::wstring MetaJson)
			{
				m_tp2->CreateAsync(
					StringConverter::nativeToManaged(PrinterName), 
					StringConverter::nativeToManaged(MetaJson));
			}

			void PrinterAPICore::BatchUpdate(std::wstring DataJson)
			{
				m_tp2->BatchUpdate(StringConverter::nativeToManaged(DataJson));
			}
		}
	}
}