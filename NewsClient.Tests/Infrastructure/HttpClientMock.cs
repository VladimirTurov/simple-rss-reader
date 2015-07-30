namespace NewsClient.Tests.Infrastructure
{
	using System;
	using System.Threading.Tasks;
	using NewsClient.Infrastructure;

	internal enum SampleDataPreference
	{
		None,
		LentaRu,
		GazetaRu
	}

	internal class HttpClientMock : IHttpClient
	{
		public SampleDataPreference SampleDataPreference { get; set; }

		public async Task<string> GetStringAsync(Uri uri)
		{
			switch (SampleDataPreference)
			{
				case SampleDataPreference.None:
					return string.Empty;

				case SampleDataPreference.LentaRu:
					return GetLentaRuSample();

				case SampleDataPreference.GazetaRu:
					return GetGazetaRuSample();

				default:
					throw new NotImplementedException();
			}
		}

		private string GetLentaRuSample()
		{
			return @"<?xml version=""1.0"" encoding=""UTF-8""?>
<rss version=""2.0"" xmlns:atom=""http://www.w3.org/2005/Atom"">
  <channel>
    <language>ru</language>
    <title>Lenta.ru : Новости</title>
    <description>Новости, статьи, фотографии, видео. Семь дней в неделю, 24 часа в сутки</description>
    <link>http://lenta.ru</link>
    <image>
      <url>http://assets.lenta.ru/small_logo.png</url>
      <title>Lenta.ru</title>
      <link>http://lenta.ru</link>
      <width>134</width>
      <height>22</height>
    </image>
    <atom:link rel=""self"" type=""application/rss+xml"" href=""http://lenta.ru/rss""/>
		
		<item>
			<guid>http://lenta.ru/news/2015/07/29/morceau_misterieux/</guid>
			<title>На побережье французского острова в Индийском океане нашли обломок самолета</title>
			<link>http://lenta.ru/news/2015/07/29/morceau_misterieux/</link>
			<description>
				<![CDATA[На побережье французского острова Реюньон, расположенного в Индийском океане к востоку от Мадагаскара, найден обломок неизвестного самолета. Специалисты считают, что трехметровая деталь могла принадлежать малайзийскому «Боингу», который пропал в ночь на 8 марта 2014 года.]]>
			</description>
			<pubDate>Wed, 29 Jul 2015 19:23:00 +0300</pubDate>
			<enclosure url=""http://icdn.lenta.ru/images/2015/07/29/18/20150729183227894/pic_df052e4cec4b74c4b14d369026bcef69.jpg"" length=""52681"" type=""image/jpeg""/>
			<category>Мир</category>
		</item>
		
		<item>
			<guid>http://lenta.ru/news/2015/07/29/beauty/</guid>
			<title>Российские ученые проверили Стандартную модель на прочность</title>
			<link>http://lenta.ru/news/2015/07/29/beauty/</link>
			<description>
				<![CDATA[Коллаборация LHCb, работающая на Большом адронном колайдере, провела измерение параметра, описывающего переход прелестного кварка b в u-кварк с излучением W-бозона. Результаты исследований могли привести к обнаружению неточностей в используемой сейчас теории, так называемой Стандартной модели.]]>
			</description>
			<pubDate>Wed, 29 Jul 2015 19:16:00 +0300</pubDate>
			<enclosure url=""http://icdn.lenta.ru/images/2015/07/29/13/20150729130711227/pic_984bbc4dc19cf8c6204cf61f03503d24.jpg"" length=""26901"" type=""image/jpeg""/>
			<category>Наука и техника</category>
		</item>
		
		<item>
			<guid>http://lenta.ru/news/2015/07/29/svyaznoy/</guid>
			<title>Связной банк ограничил пополнение вкладов</title>
			<link>http://lenta.ru/news/2015/07/29/svyaznoy/</link>
			<description>
				<![CDATA[Связной банк объявил о временном запрете на пополнение банковских вкладов с 29 июля. Пополнение текущих и карточных счетов при этом продолжается без ограничений. Решение было принято в исполнение предписания, направленного Банком России. О дате снятия ограничений будет объявлено дополнительно.<br />]]>
			</description>
			<pubDate>Wed, 29 Jul 2015 18:35:38 +0300</pubDate>
			<enclosure url=""http://icdn.lenta.ru/images/2015/07/29/17/20150729173536385/pic_35789e021851b4d422fa67e27c3f9a05.jpg"" length=""43167"" type=""image/jpeg""/>
			<category>Финансы</category>
		</item>

  </channel>
</rss>
";
		}

		private string GetGazetaRuSample()
		{
			return @"<?xml version=""1.0"" encoding=""windows-1251""?>
<rss version=""2.0"">
	<channel>
		<title>Газета.Ru - Хроника дня</title>
		<link>http://www.gazeta.ru/news/lenta/</link>
		<description>Новости в режиме он-лайн из всех областей жизни. Собственная информация, а также сообщения крупнейших российских и мировых информационных агентств</description>
		<pubDate>Wed, 29 Jul 2015 19:21:07 +0300</pubDate>
		<language>ru</language>
		<copyright>Gazeta.Ru</copyright>
		<webMaster>webmaster@gazeta.ru</webMaster>
		<ttl>20</ttl>
		
		<item>
			<title>Минюст включил Национальный фонд в поддержку демократии в список нежелательных организаций</title>
			<link>http://www.gazeta.ru/politics/news/2015/07/29/n_7419181.shtml</link>
			<author>Газета.Ru</author>
			<pubDate>Wed, 29 Jul 2015 19:17:05 +0300</pubDate>
			<description>Министерство юстиции России включило Национальный фонд в поддержку демократии в список иностранных и международных неправительственных организаций, деятельность которых на территории страны признана нежелательной. Об этом сообщается на ...</description>
			<guid>http://www.gazeta.ru/politics/news/2015/07/29/n_7419181.shtml</guid>
		</item>
		
		<item>
			<title>Мутко: просто так это ФИБА сойти с рук не может</title>
			<link>http://www.gazeta.ru/sport/news/2015/07/29/n_7419157.shtml</link>
			<author>Газета.Ru</author>
			<pubDate>Wed, 29 Jul 2015 19:09:26 +0300</pubDate>
			<description>
				Министр спорта России Виталий Мутко высказал свое мнение по поводу дисквалификации Российской федерации баскетбола (РФБ).

				29 июля Международная федерация баскетбола (ФИБА) отстранила российские сборные от участия в соревнованиях под ...
			</description>
			<guid>http://www.gazeta.ru/sport/news/2015/07/29/n_7419157.shtml</guid>
		</item>
		
		<item>
			<title>Петиция против передачи Исаакиевского собора РПЦ собрала более 6 тыс подписей</title>
			<link>http://www.gazeta.ru/social/news/2015/07/29/n_7419113.shtml</link>
			<author>Газета.Ru</author>
			<pubDate>Wed, 29 Jul 2015 19:09:12 +0300</pubDate>
			<description>
				Петиция против передачи Исаакиевского собора в собственность РПЦ на данный момент собрала 6553 подписей на сайте Change.org.
				<br /> <br></br>
				&quot;Существуют небезосновательные опасения, что усилий РПЦ будет недостаточно для проведения масштабных ...
			</description>
			<guid>http://www.gazeta.ru/social/news/2015/07/29/n_7419113.shtml</guid>
		</item>

		<rss2lj:owner xmlns:rss2lj=""http://rss2lj.net/NS"">gazeta_admin</rss2lj:owner>
	</channel>
</rss>
";
		}
	}
}