# Study-OPC-UA-.NET

## 개요
본 Repository의 목적은 .Net 환경에서의 OPC UA 학습을 처음시작하려는 분들에게 도움이 되기 위함입니다.

 OPC Foundation에서는 .Net 환경에서의 OPC UA 개발과 관련하여 아래 2개의 Repository를 통해 SDK, Library, Sample Application 등 꽤 많은 자료와 코드를 공개하고 있습니다.

https://github.com/OPCFoundation/UA-.NET<br>
https://github.com/OPCFoundation/UA-.NETStandardLibrary


 그러나, 설명이 영문으로 되어 있고 상당히 많은 요소들이 포함되어 있기 때문에 처음 학습을 시작할 때 다소 어려움이 있을 수 있다고 생각됩니다.

 저 역시 OPC UA를   학습하기 시작한지 얼마되지 않았지만, 학습하면서 알게된 지식이나 know-how를 공유하여 OPC UA를 공부해 보려는 분들의 시행착오를 조금이라도 줄이는데 도움이 되었으면 합니다.
 부정확한 내용이 있을수 있음을 참조해 주시고, 틀린 내용이 있으면 Full Request나 Issue 등록 등을 통해 알려 주시길 부탁드립니다.

 상기의 두 Repostiory는 동일하거나 유사해 보이는 프로젝트를 많이 포함하고 있으나, Certificates 처리 등 미세하게 다른 부분들이 있고,
 가장 큰 차이점은 UA-.NETStandardLibrary는 .Net Standard 프레임워크를 사용하여 Linux, iOS, Android를 포함하여 Cloud환경도 지원한다는 점입니다.<br>
 멀티플랫폼을 지원하는 UA-.NETStandardLibrary을 활용하는 것이 좀 더 바람직하겠으나, 라이브러리/모듈 의존관계가 복잡하고 OPC Foundation에서 제공하는 샘플 패키지 역시 UA-.Net으로 개발되어 있으므로, 처음에는 UA-.NET으로 학습을 시작하는게 효율적일 것 같습니다. <br>
 따라서 본 Repository는 UA-.NET Repository를 베이스로 합니다.

<br>
여기서 부터는 간결함을 위해 반말체로 작성하겠습니다.


## 사전 요구사항 및 추천사항
 - Visual Studio 2017<br>
  . UA-.NETStandardLibrary 가 Visual Studio 2017로 작성되어 있음<br>
   따라서 이전 버전의 Visual Studio를 사용하는 경우 프로젝트 형식 문제등으로 프로젝트가 로드되지 않을 수 있음<br>
   아래 링크를 참조하여 해결해 볼 수 있으나 Visual Studio 2017 사용 추천<br>
 https://stackoverflow.com/questions/42509313/the-default-xml-namespace-of-the-project-must-be-the-msbuild-xml-namespace  
 
 - .Net Framework 4.6.1<br>

 - UWP나 크로스플랫폼 연관 프로젝트가 로드되지 않는 경우 해당 프로젝트를 솔루션에서 삭제하거나<br>
   Visual Studio에 해당 Work Load를 추가 설치한다. (Work Load 추가 설치를 추천하나 꽤 용량을 많이 차지한다)

 - 개발할 내용을 파악하거나 테스트를 하기 위해 'Sample Applcation' 바이너리 패키지를 미리 설치 하는 것을 추천(회원 가입 필요)<br>
https://opcfoundation.org/developer-tools/developer-kits-unified-architecture/sample-applications/

 - OPC UA 관련 프로그램을 빌드하고 실행하기 위해서는 'CertificateGenerator'와 'Local Discovery Server(LDS)'가 필요할 수 있음<br>
  직접 빌드해서 사용할 수도 있으나 C++ 개발환경을 구축한다거나 Open SSL을 빌드해서 추가해야 하는등 귀찮고 번거로운 점이 많음.<br>
 시작부터 진을 빼지 않기 위해, 다시 한번 'Sample Applcation'패키지를 다운받아 설치 할 것을 추천.<br>
 패키지에는 CertificateGenerator와 LDS가 포함되어 있음

 - Certificate Generator 빌드<br>
  https://github.com/OPCFoundation/Misc-Tools 에서 소스코드를 받아 빌드<br>
  (Copy the CertificateGenerator output to the .NET Sample Applications output directory)


 - Local Discovery Server(LDS) 빌드<br>
   https://opcfoundation.org/developer-tools/developer-kits-unified-architecture/local-discovery-server-lds/


## UA-.Net의 주요모듈

1.핵심모듈<br>
다음의 4가지 모듈은 OPC UA .Net의 가장 핵심적인 모듈로서 OPC UA .Net의 SDK라고 할 수 있다.
- Opc.Ua.Core : Stack으로도 불리며 Low Level의 통신, 보안, Configuration 등의 기능들이 구현되어 있음
- Opc.Ua.Server : Address Space 관리, Node관리 등 서버의 기능들이 구현되어 있음
- Opc.Ua.Cleient : Address Space 조회, Subscription 등 서버에 연결하고 데이터를 조회하는 기능들이 구현되어 있음
- Opc.Ua.Configuration : ApplicationInstant 객체 및 각종 상수값 등이 정의 되어 있음<br>

2.기타 유용한 모듈<br>
 다음의 모듈들은 OPC UA 관련 응용프로그램을 개발할 때 참조하거나 사용할 수 있는 UI Control들을 포함하고 있으며 상용제품이 아닌 프로토타입이나 학습을 위한 프로그램을 만들때 유용하다.<br>
- Opc.Ua.SampleControls<br>
- Opc.Ua.ServerControls<br>
- Opc.Ua.ClientControls<br>
<br>

## OPC UA와 OPC Classsic의 주요 차이점

OPC UA와 OPC Classic의 가장 큰 차이점은 보안에 대한 기능 강화와 OPC UA가 플랫폼 독립적인 기술이라는 것이다.<br>
특히, OPC UA의 보안에 대한 내용은 OPC UA를 학습하고자 할 때 가장 먼저 만나게 되는 걸림돌이라 생각된다.<br>
 따라서, OPC UA를 본격적으로 학습하기 전에 OPC UA의 보안 메카니즘에 대해서 어느정도 학습할 것을 권장한다.<br>
OPC UA는 인증서나 암호화를 사용하지 않고도 통신을 할 수 있도록 되어 있으나, 코드를 분석하다 보면 보안관련 내용과 계속 맞닺뜨리게 되어 있다.<br>


## OPC UA의 보안단계 (Security Tier)
 OPC UA의 보안은 인증(Authentication), 통신 암호화(Encryption), 권한(Authorization) 으로 나눌 수 있고, 인증은 다시 Application 인증과 사용자 인증으로 나눌 수 있다. <br>
 OPC UA를 학습함에 있어 우선적으로 집중해야 할 것은 Applicatioin 인증 메카니즘에 대해 이해하는 것이라 생각된다.

 OPC UA는 인증 기능 구현을 위해 X.509(인증서)를 활용한다.<br>
 인증이란 "내가 진짜 나라는 걸 증명 하는 것"이라 할 수 있는데, 서버는 접속을 요청한 클라이언트가 사전에 허용된 그 클라이언트가 맞는지 확인 후 접속을 받아 들여야 하고, 클라이언트 역시 지금 접속하고 있는 서버가 내가 접속하고자 하는 서버가 진짜 맞는지 확인 후 통신을 해야한다.<br>
 그러나 OPC UA에서 인증기능이 강제되어 있는 것은 아니고 선택적으로 적용할 수 있다.<br>
따라서 4가지 케이스가 있을 수 있는데 OPC UA에서는 이 4가지 모두 사용할 수 있다. <br>
(OPC UA Security Model에서는 이를 Security Tier라고 한다)<br>

 - Tier 1 : No Authenication<br>
 클라이언트, 서버 모두 상대방이 믿을 만한 상대인지 확인하지 않는 모드이다. 그러나 이경우에도 유효한 인증서를 상호간에 교환해야 하고 유효하지
않은 인증서인 경우 통신에 실패한다. 인증기능을 사용하지 않을지라도 인증에 대해 알아야 하는 이유중 하나이다.<br>
 물리적으로 고립된 네트웍이거나 보안이 필요없는 공공 데이터인 경우에 고려 할 수 있는 방식이다.

- Tier 2 : Server Authentication<br>
  서버는 모든 클라이언트의 접속을 허용하고 클라이언트가 유효한 서버인지를 확인하는 모드이다. 서버에서 사용자 인증이 필요한 경우 id/password 정보, 사용자의 개인인증서를 활용할 수 있다.<br>
  클라이언트는 서버가 보낸 인증서가 자신이 신뢰하는 CA(Certificate Authority)에서 발행한 인증서이거나, 신뢰하는 인증서로 등록되어 있는 경우
통신을 허용한다.<br>
 신뢰하는 인증서로 등록되어 있지 않은 경우 인증서의 도메인 정보와 실제 접속하고 있는 서버의 도메인이 일치하는지 확인하고 일치하면 접속을 허용한다.


- Tier 3 - Client Authentication<br>
  클라이언트는 검증없이 서버에 접속하고 서버에서 클라이언트를 인증하는 방식이다.

- Tier 4 - Mutual Authentication<br>
 서버, 클라이언트 상호간에 인증을 하고 통신하는 방식이다.



## 인증서 기반 인증

 인증서 기반의 인증은 사전에 상대방에게 인증서를 전달하고 설치하는 작업이 필요하다.<br>
불특정 다수의 Server나 Application을 대상으로 하는 경우 상당히 고단한 작업이 될 것이고, 공공을 대상으로 하는 경우에는 CA를 활용하지 않고서는 관리나 운영이 거의 불가능하다고 할 것이다.<br>
 대다수의 기업 환경(사내망내에서 운영)에서는, 클라이언트 설치 시 서버(Application)의 인증서를 신뢰하는 인증서로 등록 되도록 하고,
서버에서는 id/password로 클라이언트 접속을 허용하도록 하는 방식이 가장 적합하지 않을까 싶다.

 정리하자면,<br>
첫째, 어떤 인증모드를 사용하든지, 심지어 No Authentication 모드를 사용한다 할지라도 인증서(Cerificate)를 만들어야 하고 상호 교환해야 한다.<br>
둘째, 인증 기능을 사용하려면 선택한 방식에 따라 인증서를 상대방에게 사전에 전달하고 등록해야 한다.


 UA-.NETStandardLibrary 예제 프로그램들의 경우, ApplicationInstance 객체의 CheckApplicationInstanceCertificate() 메소드를 호출하여 만들어진 인증서가 없는 경우 자동으로 만들어지도록 되어 있다. 이를 self-signed certificates 라고 한다.<br>
 만들어진 인증서는 기본적으로 아래 2폴더에 동시에 생성된다.<br>
 C:\ProgramData\OPC Foundation\CertificateStores\MachineDefault\certs<br>
 C:\ProgramData\OPC Foundation\CertificateStores\UA Applications\certs

 OPC UA Foundation에서 제공하는 예제들의 경우 신뢰하는 인증서 디렉토리는 <br>
 'C:\ProgramData\OPC Foundation\CertificateStores\UA Applications\certs'이며, 이는 Configuration 파일의 'TrustedIssuerCertificates' 섹션에 지정되어 있다.<br>
 예제 프로그램에서 Configuration 파일은 app.config 파일의 설정 또는 어셈블리 네임을 기준으로 자동으로 찾도록 되어 있으며 기본적으로 "프로그램이름.config.xml" 파일이다.<br><br>

 즉, Tier 2인 경우 서버 Applciation의 인증서를 Client 컴퓨터의 'C:\ProgramData\OPC Foundation\CertificateStores\UA Applications\certs' 폴더로 사전에 copy 해 놓을 필요가 있다.<br>
 또는 신뢰하고자 하는 인증서가 접속 실패 후 'RejectedCertificates'폴더에 생성된 경우 이를 신뢰 인증서 폴더로 이동하여 처리 할 수 있다.<br>
 UA-.NETStandardLibrary 예제 프로그램에서는 사전에 신뢰할 수 있는 인증서로 등록되어 있지 않은 경우, 신뢰할 수 없는 인증서라는 경고와 함께 계속 진행하겠냐고 묻는 대화상자가 뜨고 '예'를 누르는 경우 통신을 할 수 있게 되어있다.


- ThumbPrint<br>
 인증서 파일명을 보면 대괄호 안에 긴 숫자와 알파벳이 있는데 이를 ThumbPrint라고 한다.
 기본적으로 인증서는 인증서 내의 Component Name(CN)으로 구분하는데 단순 문자열이므로 중복될 수 있다.
중복되는 경우 먼저 발견된 인증서를 사용하도록 되어 있고, 인증서를 명확하게 구분할 필요가 있는 경우 사용하는 것이 ThumbPrint이다.
Cofiguration 파일에서 ThumbPrint를 명시할 수 있다.


- 인증서 저장소<br>
 Windows 환경에서는 인증서를 저장할 수 있는 곳(Store)으로 'Windows'와 'Directory'가 있다. 'Windows'는 윈도우 OS에서 제공하는 레지스트리 기반의 저장소이고
'Directory'는 앞서 살펴본 파일기반의 인증서 저장소를 말한다.
 UA-.NETStandardLibrary 예제의 경우 소스를 내려 받고 실행하면 에러가 발생하는데, Configuration 파일에서 'StoreType'의 값을 'Directory'로 변경하고
폴더 경로를 설정하고 나니 에러가 해결되었다.


- ConfigurationTool<br>
 Sample 패키지를 설치한 경우 Opc.Ua.ConfigurationTool.exe 을 실행하여 인증서 관리 작업을 간편하게 처리할 수 있다.
<br>

 인증 관련 테스트를 위해서는 별도의 컴퓨터나 가상환경을 활용하여 클라이언트와 서버를 분리하는 것을 권장한다.



## OPC UA의 통신 처리 절차

1. 클라이언트가 서버에게 End Point 정보 요청
   (End Point에는 인증방식, 암호화 방식등의 정보가 포함되어 있으며, 하나의 서버는 여러개의 End Point를 가질 수있다)
2. 서버가 클라이언트에게 인증서와 함께 End Point 정보제공
3. 클라이언트는 서버가 보낸 인증서 검증 (접속하고자 하는 그 서버가 맞는가)
4. 클라이언트는 클라이언트 인증서와 함께 서버에게 Channel 생성 요청
5. 서버에서는 클라이언트가 보낸 인증서를 검증하고 Channel Open
6. Channel이 오픈되면 클라이언트에서 서버에게 Session 생성 요청
7. 서버에서는 Session ID 응답
8. 클라이언트에서 (사용자 인증 정보 Token 와 함께) Activate Session 요청
9. 서버에서는 Token을 검증하고 해당하는 권한에 맞게 Session Activate
10. 암화화 통신


## Address Space
Address Space는 OPC UA의 데이터 저장소 또는 데이터 모델이라고 할 수 있다.<br>
Address Space는 Node와 Node의 관계를 통해 객체지향적으로 데이터 모델을 구성한다.<br>
Node는 Object, Variable, Method, View, ObjectType,VariableType, ReferencyType, DataType 중에 하나가 되며, 이를 Node Class라고 한다.
Node는 Node를 설명하는 Attributes와 다른 노드와의 관계를 나타내는 References를 가진다.<br>
Object의 노드의 경우 Variable들과 Methoe들을 가지고 Client는 이를 통해 값을 조회하거나 Event를 통보 받거나 서비스를 호출 할 수 있다.<br>
Variable 노드는 Property와 Data Variable 두 종류로 나뉘어지고 Property는 object의 Meata 데이터를 정의하는데 사용되고, Data Variable은 Object가 제공하고자 하는 실제 Data를 표현하는데 사용된다.<br>
Attribute는 OPC UA Spec에 의해 정해져 있으므로 추가 될 수 없지만 Property는 추가가 가능하다.<br>




## 예제 프로젝트

### Minimal Client
- 최소한의 코드로 OPC UA Client를 구현
- config 파일도 사용하지 않음(xxx.config.xml, app.config)
- 신뢰할 수 없는 (서버)인증서를 허용하도록 설정
- Opc.Ua.Sample.Controls.BrowseTreeCtrl을 사용하여 Address Space 조회
  샘플 컨트롤을 사용하지 않는 경우 Session.Browse() 메소드를 통해 
  Address Space를 조회 할 수 있음
- BrowseTreeCtrl 에서 노드를 선택하고 마우스 오른쪽 버튼 클릭하면 속성 및 값을 조회할 수 있음
- 실행 흐름은 다음과 같음
  . Configuration 객체 생성 및 설정
  . Session 객체 생성
  . Session을 통해 Address Space조회
- 조회할 Node정보를 아는 경우 Session.ReadValue() 메소드를 사용하여 개별 Node정보를 조회 할 수 있음<br>
var node = _session.ReadValue(new NodeId("ns=x;i=xxxx"));


### Mimimal Server
- 최소한의 코드로 OPC UA Server 구현
- config 파일도 사용하지 않음(xxx.config.xml, app.config)
- 인증서 생성 및 인증서 저장소 설정은 필요


### Mimimal Client With Certification
- app.config와 OPC UA를 위한 XML설정 파일 사용
- application.ConfigSectionName에 XML설정파일 경로를 가지고 있는
  app.config 파일내의 Section을 설정
- application.LoadApplicationConfiguration()에서 app.config를 참조하여
  OPC UA 설정 파일을 찾고, 이것을 로드하여 configuration 객체 생성
- 설정파일에는 "SecurityConfiguration" 영역과 "ClientConfiguration" 영역이 있음
- "SecurityConfiguration"에는 주로 인증서 관련 설정이, "ClientConfiguration" 에는
  End Point 검색 및 통신에 관련된 내용이 있음
- Application Type이 서버인 경우 "ClientConfiguration" 대신 "ServerConfiguration" 영역이 필요

### Server 및 Endpoint 정보 조회


### Subscription 기능




## Troubleshooting
### 인증서 관련 문제가 발생하는 경우
 . 인증서 Directory를 백업하고 인증서들을 삭제해 본다<br>
 . 'Opc.Ua.CertificateGenerator.exe'가 존재하는지 확인하고
   어플리케이션이 존재하는 폴더로 복사해 본다

## 참고 사이트
 https://opcfoundation.org/<br>
 http://opcfoundation.github.io/UA-.NET/<br>
 http://opcfoundation.github.io/UA-.NET/help/index.htm<br>
 http://wiki.opcfoundation.org/index.php/UA_Overview<br>
 http://documentation.unified-automation.com/uasdkdotnet/2.5.5/html/index.html<br>

