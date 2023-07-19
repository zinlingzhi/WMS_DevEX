using System.Reflection;
//
// �йس��򼯵ĳ�����Ϣ��ͨ������ 
//���Լ����Ƶġ�������Щ����ֵ���޸������
//��������Ϣ��
//
[assembly : AssemblyTitle("���ݷ�����")]
[assembly : AssemblyDescription("��־�򿪷�")]
[assembly : AssemblyConfiguration("BruceJin")]
[assembly : AssemblyCompany("�������")]
[assembly : AssemblyProduct("�������ݷ���")]
[assembly : AssemblyCopyright("Liuand2001@sina.com.cn")]
[assembly : AssemblyTrademark(" (^��^)")]
[assembly : AssemblyCulture("")]

//
// ���򼯵İ汾��Ϣ�������� 4 ��ֵ��
//
//      ���汾
//      �ΰ汾
//      �ڲ��汾��
//      �޶���
//
// ������ָ������ֵ����ʹ�á��޶��š��͡��ڲ��汾�š���Ĭ��ֵ������Ϊ�����·�ʽ 
// ʹ�á�*����

[assembly : AssemblyVersion("1.0.0.0")]

//
// Ҫ�Գ��򼯽���ǩ��������ָ��Ҫʹ�õ���Կ���йس���ǩ���ĸ�����Ϣ����ο� 
// Microsoft .NET ����ĵ���
//
// ʹ����������Կ�������ǩ������Կ��
//
// ע�⣺
//   (*) ���δָ����Կ������򼯲��ᱻǩ����
//   (*) KeyName ��ָ�Ѿ���װ�ڼ�����ϵ�
//      ���ܷ����ṩ���� (CSP) �е���Կ��KeyFile ��ָ����
//       ��Կ���ļ���
//   (*) ��� KeyFile �� KeyName ֵ����ָ������ 
//       �������д�����
//       (1) ����� CSP �п����ҵ� KeyName����ʹ�ø���Կ��
//       (2) ��� KeyName �����ڶ� KeyFile ���ڣ��� 
//           KeyFile �е���Կ��װ�� CSP �в���ʹ�ø���Կ��
//   (*) Ҫ���� KeyFile������ʹ�� sn.exe��ǿ���ƣ�ʵ�ù��ߡ�
//       ��ָ�� KeyFile ʱ��KeyFile ��λ��Ӧ�������
//       ��Ŀ���Ŀ¼����
//       %Project Directory%\obj\<configuration>�����磬��� KeyFile λ��
//       ����ĿĿ¼��Ӧ�� AssemblyKeyFile 
//       ����ָ��Ϊ [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) ���ӳ�ǩ������һ���߼�ѡ�� - �й����ĸ�����Ϣ������� Microsoft .NET ���
//       �ĵ���
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]