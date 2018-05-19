using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFRKApi.Logic.Api.CharacterRating
{
    public interface IAltemaCharacterJapaneseTextMapper
    {
        string GetCharacterNameFromId(string altemaCharacterId);

        string GetRoleSummaryFromJapaneseRoleSummary(string japaneseRole);

        IList<string> GetRolesFromJapaneseRoleSummary(string japaneseRoleSummary);
    }


    public class AltemaCharacterJapaneseTextMapper : IAltemaCharacterJapaneseTextMapper
    {
		private readonly IDictionary<string, string> _characterNameMap = new Dictionary<string, string>()
		{
			{"/ffrk/character/32", "Cloud"},	// クラウド
			{"/ffrk/character/328", "Elarra"},	// 	ウララ
			{"/ffrk/character/64", "Tyro"},	// デシ
			{"/ffrk/character/41", "Rinoa"},	// 	リノア
			{"/ffrk/character/50", "Tidus"},	// 	ティーダ
			{"/ffrk/character/202", "Yuffie"},	// 	ユフィ
			{"/ffrk/character/217", "Ramza"},	// 	ラムザ
			{"/ffrk/character/249", "Onion Knight"},	// 	オニオンナイト
			{"/ffrk/character/21", "Bartz"},	// バッツ
			{"/ffrk/character/23", "Terra"},	// 	ティナ
			{"/ffrk/character/35", "Aerith"},	// 	エアリス
			{"/ffrk/character/38", "Sephiroth"},	// 	セフィロス
			{"/ffrk/character/96", "Ingus"},	// 	イングズ
			{"/ffrk/character/221", "Vincent"},	// 	ヴィンセント
			{"/ffrk/character/257", "Orlandeau"},	// 	オルランドゥ
			{"/ffrk/character/13", "Kain"},	// カイン
			{"/ffrk/character/33", "Tifa"},	// ティファ
			{"/ffrk/character/58", "Ashe"},	// 	アーシェ
			{"/ffrk/character/104", "Edge"},	// 	エッジ
			{"/ffrk/character/224", "Shantotto"},	// 	シャントット
			{"/ffrk/character/334", "Enna"},	// 	エナクロ
			{"/ffrk/character/3", "Maria"},	// 	マリア
			{"/ffrk/character/46", "Garnet"},	// 	ガーネット
			{"/ffrk/character/47", "Vivi"},	// 	ビビ
			{"/ffrk/character/215", "Palom"},	// パロム
			{"/ffrk/character/263", "Fujin"},	// 	風神
			{"/ffrk/character/330", "Sora"},	// 	ソラ
			{"/ffrk/character/24", "Locke"},	// 	ロック
			{"/ffrk/character/25", "Celes"},	// 	セリス
			{"/ffrk/character/39", "Squall"},	// 	スコール
			{"/ffrk/character/324", "King"},	// 	キング
			{"/ffrk/character/331", "Riku"},	// 	リク
			{"/ffrk/character/100", "Krile"},	// 	クルル
			{"/ffrk/character/210", "Jecht"},	// 	ジェクト
			{"/ffrk/character/211", "Laguna"},	// 	ラグナ
			{"/ffrk/character/22", "Gilgamesh"},	// 	ギルガメッシュ
			{"/ffrk/character/37", "Zack"},	// 	ザックス
			{"/ffrk/character/40", "Seifer"},	// 	サイファー
			{"/ffrk/character/265", "Vayne"},	// 	ヴェイン
			{"/ffrk/character/325", "Cinque"},	// 	シンク
			{"/ffrk/character/1", "Warrior of Light"},	// 	光の戦士
			{"/ffrk/character/8", "Luneth"},	// 	ルーネス
			{"/ffrk/character/49", "Eiko"},	// 	エーコ
			{"/ffrk/character/220", "Relm"},	// 	リルム
			{"/ffrk/character/233", "Garland"},	// 	ガーランド
			{"/ffrk/character/308", "Prompto"},	// 	プロンプト
			{"/ffrk/character/17", "Golbez"},	// 	ゴルベーザ
			{"/ffrk/character/36", "Red XIII"},	// 	レッドXIII
			{"/ffrk/character/44", "Selphie"},	// 	セルフィ
			{"/ffrk/character/59", "Lightning"},	// 	ライトニング
			{"/ffrk/character/95", "Shadow"},	// 	シャドウ
			{"/ffrk/character/254", "Dorgann"},	// 	ドルガン
			{"/ffrk/character/314", "Marche"},	// 	マーシュ
			{"/ffrk/character/326", "Ignis"},	// 	イグニス
			{"/ffrk/character/20", "Galuf"},	// 	ガラフ
			{"/ffrk/character/54", "Auron"},	// 	アーロン
			{"/ffrk/character/101", "Rikku"},	// 	リュック
			{"/ffrk/character/105", "Rosa"},	// 	ローザ
			{"/ffrk/character/291", "Ace"},	// 	エース
			{"/ffrk/character/15", "Edward"},	// 	ギルバート
			{"/ffrk/character/30", "Strago"},	// 	ストラゴス
			{"/ffrk/character/236", "Sarah"},	// 	セーラ
			{"/ffrk/character/332", "Sice"},	// 	サイス
			{"/ffrk/character/206", "Penelo"},	// 	パンネロ
			{"/ffrk/character/298", "Aphmau"},	// 	アフマウ
			{"/ffrk/character/300", "Iris"},	// 	イリス
			{"/ffrk/character/11", "Cecil (Dark Knight)"},	// 	セシル(暗黒騎士)
			{"/ffrk/character/99", "Faris"},	// 	ファリス
			{"/ffrk/character/55", "Vaan"},	// 	ヴァン
			{"/ffrk/character/98", "Reno"},	// 	レノ
			{"/ffrk/character/228", "Serah"},	// 	セラ
			{"/ffrk/character/232", "Kuja"},	// 	クジャ
			{"/ffrk/character/259", "Seymour"},	// 	シーモア
			{"/ffrk/character/19", "Lenna"},	// 	レナ
			{"/ffrk/character/242", "Ovelia"},	// 	オヴェリア
			{"/ffrk/character/247", "Larsa"},	// 	ラーサー
			{"/ffrk/character/318", "Rem"},	// レム
			{"/ffrk/character/12", "Cecil (Paladin)"},	// 	セシル(パラディン)
			{"/ffrk/character/14", "Rydia"},	// 	リディア
			{"/ffrk/character/42", "Quistis"},	// 	キスティス
			{"/ffrk/character/204", "Beatrix"},	// 	ベアトリクス
			{"/ffrk/character/208", "Kefka"},	// 	ケフカ
			{"/ffrk/character/238", "Yang"},	// 	ヤン
			{"/ffrk/character/268", "Lann"},	// 	ラァン
			{"/ffrk/character/292", "Deuce"},	// 	デュース
			{"/ffrk/character/295", "Shelke"},	// 	シェルク
			{"/ffrk/character/323", "Kelger"},	// 	ケルガー
			{"/ffrk/character/327", "Barbariccia"},	// 	バルバリシア
			{"/ffrk/character/335", "Tama"},	// 	タマ
			{"/ffrk/character/26", "Mog"},	// 	モグ
			{"/ffrk/character/27", "Edgar"},	// 	エドガー
			{"/ffrk/character/264", "Raijin"},	// 	雷神
			{"/ffrk/character/287", "Reks"},	// 	レックス
			{"/ffrk/character/294", "Cid (XIV)"},	// 	シド(FF14)
			{"/ffrk/character/43", "Zell"},	// 	ゼル
			{"/ffrk/character/62", "Sazh"},	// 	サッズ
			{"/ffrk/character/214", "Minwu"},	// 	ミンウ
			{"/ffrk/character/243", "Cid Raines"},	// 	レインズ
			{"/ffrk/character/28", "Sabin"},	// 	マッシュ
			{"/ffrk/character/103", "Y'shtola"},	// 	ヤ・シュトラ
			{"/ffrk/character/107", "Fang"},	// 	ファング
			{"/ffrk/character/9", "Arc"},	// 	アルクゥ
			{"/ffrk/character/51", "Yuna"},	// 	ユウナ
			{"/ffrk/character/89", "Zidane"},	// 	ジタン
			{"/ffrk/character/29", "Cyan"},	// 	カイエン
			{"/ffrk/character/56", "Balthier"},	// 	バルフレア
			{"/ffrk/character/61", "Vanille"},	// 	ヴァニラ
			{"/ffrk/character/218", "Agrias"},	// 	アグリアス
			{"/ffrk/character/225", "Porom"},	// 	ポロム
			{"/ffrk/character/229", "Cait Sith"},	// 	ケットシー
			{"/ffrk/character/297", "Zeid"},	// 	ザイド
			{"/ffrk/character/7", "Josef"},	// 	ヨーゼフ
			{"/ffrk/character/31", "Setzer"},	// 	セッツァー
			{"/ffrk/character/234", "Papalymo"},	// 	パパリモ
			{"/ffrk/character/305", "Aria"},	// 	エリア
			{"/ffrk/character/10", "Refia"},	// 	レフィア
			{"/ffrk/character/60", "Snow"},	// 	スノウ
			{"/ffrk/character/63", "Hope"},	// 	ホープ
			{"/ffrk/character/106", "Quina"},	// 	クイナ
			{"/ffrk/character/252", "Leo"},	// 	レオ将軍
			{"/ffrk/character/271", "Prishe"},	// 	プリッシュ
			{"/ffrk/character/222", "Basch"},	// 	バッシュ
			{"/ffrk/character/235", "Yda"},	// 	イダ
			{"/ffrk/character/289", "Aemo"},	// 	エモ
			{"/ffrk/character/315", "Montblanc"},	// 	モンブラン
			{"/ffrk/character/320", "Alma"},	// 	アルマ
			{"/ffrk/character/239", "Gabranth"},	// 	ガブラス
			{"/ffrk/character/273", "Rapha"},	// 	ラファ
			{"/ffrk/character/248", "Noel"},	// 	ノエル
			{"/ffrk/character/250", "Ayame"},	// 	アヤメ
			{"/ffrk/character/255", "Alphinaud"},	// 	アルフィノ
			{"/ffrk/character/288", "Morrow"},	// 	トゥモロ
			{"/ffrk/character/309", "Aranea"},	// 	アラネア
			{"/ffrk/character/312", "Estinien"},	// 	エスティニアン
			{"/ffrk/character/329", "Ultimecia"},	// 	アルティミシア
			{"/ffrk/character/227", "Desch"},	// 	デッシュ
			{"/ffrk/character/267", "Cloud of Darkness"},	// 	くらやみのくも(暗闇の雲)
			{"/ffrk/character/277", "Noctis"},	// 	ノクティス
			{"/ffrk/character/310", "Ysayle"},	// 	イゼル
			{"/ffrk/character/317", "Machina"},	// 	マキナ
			{"/ffrk/character/231", "Echo"},	// 	エコー
			{"/ffrk/character/237", "Braska"},	// 	ブラスカ
			{"/ffrk/character/256", "Minfilia"},	// 	ミンフィリア
			{"/ffrk/character/5", "Gordon"},	// 	ゴードン
			{"/ffrk/character/213", "Freya"},	// 	フライヤ
			{"/ffrk/character/244", "Guy"},	// 	ガイ
			{"/ffrk/character/2", "Firion"},	// 	フリオニール
			{"/ffrk/character/91", "Cid (VII)"},	// 	シド
			{"/ffrk/character/52", "Wakka"},	// 	ワッカ
			{"/ffrk/character/53", "Kimahri"},	// 	キマリ
			{"/ffrk/character/245", "Paine"},	// 	パイン
			{"/ffrk/character/279", "Nabaat"},	// 	ナバート
			{"/ffrk/character/241", "Delita"},	// 	ディリータ
			{"/ffrk/character/251", "Curilla"},	// 	クリルラ
			{"/ffrk/character/92", "Lulu"},	// 	ルールー
			{"/ffrk/character/304", "Meliadoul"},	// 	メリアドール
			{"/ffrk/character/319", "Queen"},	// 	クイーン
			{"/ffrk/character/16", "Tellah"},	// 	テラ
			{"/ffrk/character/209", "Exdeath"},	// 	エクスデス
			{"/ffrk/character/303", "Scott"},	// 	スコット
			{"/ffrk/character/57", "Fran"},	// 	フラン
			{"/ffrk/character/223", "Edea"},	// 	イデア
			{"/ffrk/character/261", "Master"},	// 	スーパーモンク
			{"/ffrk/character/262", "Matoya"},	// 	マトーヤ
			{"/ffrk/character/276", "Gogo (V)"},	// 	ゴゴ(FF5)
			{"/ffrk/character/258", "Gaffgarion"},	// 	ガフガリオン
			{"/ffrk/character/322", "Xezat"},	// 	ゼザ
			{"/ffrk/character/4", "Leon"},	// 	レオンハルト
			{"/ffrk/character/240", "Mustadio"},	// 	ムスタディオ
			{"/ffrk/character/284", "Ward"},	// 	ウォード
			{"/ffrk/character/293", "Nine"},	// 	ナイン
			{"/ffrk/character/299", "Gladiolus"},	// 	グラディオラス
			{"/ffrk/character/333", "Seven"},	// 	セブン
			{"/ffrk/character/34", "Barret"},	// 	バレット
			{"/ffrk/character/90", "Amarant"},	// 	サラマンダー
			{"/ffrk/character/272", "Lion"},	// 	ライオン
			{"/ffrk/character/313", "Ursula"},	// 	アーシュラ
			{"/ffrk/character/269", "Reynn"},	// 	レェン
			{"/ffrk/character/278", "Meia"},	// 	メイア
			{"/ffrk/character/290", "Wrieg"},	// 	リーグ
			{"/ffrk/character/275", "Ceodore"},	// 	セオドア
			{"/ffrk/character/48", "Steiner"},	// 	スタイナー
			{"/ffrk/character/321", "Thief (I)"},	// 	シーフ(FF1)
			{"/ffrk/character/6", "Ricard"},	// 	リチャード
			{"/ffrk/character/18", "Fusoya"},	// 	フースーヤ
			{"/ffrk/character/45", "Irvine"},	// 	アーヴァイン
			{"/ffrk/character/316", "Marcus"},	// 	マーカス
			{"/ffrk/character/260", "Cid (IV)"},	// 	シド
			{"/ffrk/character/274", "Marach"},	// 	マラーク
			{"/ffrk/character/311", "Haurchefant"},	// 	オルシュファン
			{"/ffrk/character/307", "Elena"},	// 	イリーナ
			{"/ffrk/character/266", "Emperor"},	// 	こうてい(皇帝)
			{"/ffrk/character/270", "Rufus"},	// 	ルーファウス
			{"/ffrk/character/281", "Gogo (VI)"},	// 	ゴゴ(FF6)
			{"/ffrk/character/282", "Umaro"},	// 	ウーマロ
			{"/ffrk/character/306", "Rude"},	// 	ルード
			{"/ffrk/character/216", "Leila"},	// 	レイラ
			{"/ffrk/character/230", "Wol"},	// 	ウォル
			{"/ffrk/character/283", "Kiros"},	// 	キロス
			{"/ffrk/character/102", "Thancred"},	// 	サンクレッド
			{"/ffrk/character/253", "Angeal"},	// 	アンジール
			{"/ffrk/character/296", "Rubicante"},	// 	ルビカンテ
			{"/ffrk/character/207", "Gau"},	// 	ガウ
		    {"/ffrk/character/336", "Hilda"}	// 	ヒルダ
		};

		private readonly IDictionary<string, string> _roleSummaryMap = new Dictionary<string, string>()
		{
			{"風物理", "Wind ATK"},
			{"回復", "Healing"},
			{"バフ", "Buff"},
			{"デバフ", "Debuff"},
			{"オールマイティ", "Almighty"},
			{"氷地魔法", "Ice Earth MAG"},
			{"チェイン", "Chain"},
			{"水物理", "Water ATK"},
			{"聖物理", "Holy ATK"},
			{"物魔", "Hybrid"},
			{"水風地炎物理", "Water Earth Fire Wind ATK"},
			{"炎魔法", "Fire MAG"},
			{"攻バフ", "ATK Buff"},
			{"闇物理", "Dark ATK"},
			{"地物理", "Earth ATK"},
			{"炎物魔", "Fire Hybrid"},
			{"聖闇地物理", "Holy Dark Earth ATK"},
			{"雷物理", "Lightning ATK"},
			{"雷魔法", "Lightning MAG"},
			{"地魔法", "Earth MAG"},
			{"魔バフ", "MAG Buff"}, 
			{"風魔法", "Wind MAG"},
			{"炎氷雷物理", "Fire Ice Lightning ATK"},
			{"炎物理", "Fire ATK"},
			{"風氷物理", "Ice Wind Holy ATK"},
			{"魔法吸収", "Magic Absorb"},
			{"攻魔バフ", "Hybrid Buff"},
			{"氷物理", "Ice ATK"},
			{"炎闇物理", "Fire Dark ATK"},
			{"氷雷物理", "Ice Lightning ATK"},
			{"闇物魔", "Dark Hybrid"},
			{"闇魔法", "Dark MAG"},
			{"炎地物理", "Fire Earth ATK"},
			{"水魔法", "Water MAG"},
			{"雷物魔", "Lightning Hybrid"},
			{"氷魔法", "Ice MAG"},
			{"聖魔法", "Holy MAG"},
			{"地水魔法", "Earth Water MAG"},
			{"毒魔法", "Poison MAG"},
			{"闇毒魔法", "Dark Poison MAG"},
			{"炎雷毒物理", "Fire Thunder Poison ATK"},
			{"闇聖魔法", "Dark Holy MAG"},
			{"聖風魔法", "Holy Wind MAG"},
			{"聖地物理", "Holy Earth ATK"},
			{"物理", "NE ATK"},
			{"魔法", "MAG"},
			{"聖炎氷物理", "Holy Fire Ice ATK"},
			{"聖炎雷氷物理", "Holy Fire Lightning Ice ATK"},
			{"地聖物理", "Earth Holy ATK"},
			{"炎氷雷魔法", "Fire Ice Lightning MAG"},
			{"ものまね", "Mimic"},
			{"風毒物理", "Wind Poison ATK"},
			{"聖氷物理", "Holy Ice ATK"},
			{"風地魔法", "Earth Wind MAG"},
			{"地物魔", "Hybrid MAG"},
			{"毒物理", "Poison ATK"},
			{"炎毒物理", "Fire Poison ATK"}

		};

		private readonly IDictionary<string, IList<string>> _rolePartMap = new Dictionary<string, IList<string>>()
		{
			{"風物理", new List<string> { "Wind ATK" }},
			{"回復", new List<string> { "Healing" }},
			{"バフ", new List<string> {"Buff"}},
			{"デバフ", new List<string> {"Debuff"}},
			{"オールマイティ", new List<string> {"Almighty"}},
			{"氷地魔法", new List<string> {"Ice MAG", "Earth MAG"}}, //"Ice Earth MAG"
			{"チェイン", new List<string> {"Chain"}},
			{"水物理", new List<string> {"Water ATK"}},
			{"聖物理", new List<string> {"Holy ATK"}},
			{"物魔", new List<string> {"Hybrid"}},
			{"水風地炎物理", new List<string> {"Water ATK", "Earth ATK", "Fire ATK", "Wind ATK"}}, //"Water Earth Fire Wind ATK"
			{"炎魔法", new List<string> {"Fire MAG"}},
			{"攻バフ", new List<string> {"ATK Buff"}},
			{"闇物理", new List<string> {"Dark ATK"}},
			{"地物理", new List<string> {"Earth ATK"}},
			{"炎物魔", new List<string> {"Fire Hybrid"}},
			{"聖闇地物理", new List<string> {"Holy ATK", "Dark ATK", "Earth ATK"}}, //"Holy Dark Earth ATK"
			{"雷物理", new List<string> {"Lightning ATK"}},
			{"雷魔法", new List<string> {"Lightning MAG"}},
			{"地魔法", new List<string> {"Earth MAG"}},
			{"魔バフ", new List<string> {"MAG Buff"}}, //魔バフ vs 攻魔バフ
			{"風魔法", new List<string> {"Wind MAG"}},
			{"炎氷雷物理", new List<string> {"Fire ATK", "Ice ATK", "Lightning ATK"}}, //"Fire Ice Lightning ATK"
			{"炎物理", new List<string> {"Fire ATK"}},
			{"風氷物理", new List<string> {"Ice ATK", "Wind ATK", "Holy ATK"}}, //"Ice Wind Holy ATK"
			{"魔法吸収", new List<string> {"Magic Absorb"}},
			{"攻魔バフ", new List<string> {"Hybrid Buff"}}, //dup
			{"氷物理", new List<string> {"Ice ATK"}},
			{"炎闇物理", new List<string> {"Fire ATK", "Dark ATK"}}, //"Fire Dark ATK"
			{"氷雷物理", new List<string> {"Ice ATK", "Lightning ATK"}}, //"Ice Lightning ATK"
			{"闇物魔", new List<string> {"Dark Hybrid"}},
			{"闇魔法", new List<string> {"Dark MAG"}},
			{"炎地物理", new List<string> {"Fire ATK", "Earth ATK"}}, //"Fire Earth ATK"
			{"水魔法", new List<string> {"Water MAG"}},
			{"雷物魔", new List<string> {"Lightning Hybrid"}},
			{"氷魔法", new List<string> {"Ice MAG"}},
			{"聖魔法", new List<string> {"Holy MAG"}},
			{"地水魔法", new List<string> {"Earth MAG", "Water MAG"}},
			{"毒魔法", new List<string> {"Poison MAG"}},
			{"闇毒魔法", new List<string> {"Dark MAG", "Poison MAG"}}, //"Dark Poison MAG"
			{"炎雷毒物理", new List<string> {"Fire ATK", "Thunder ATK", "Poison ATK"}}, //"Fire Thunder Poison ATK"
			{"闇聖魔法", new List<string> {"Dark MAG", "Holy MAG"}}, //"Dark Holy MAG"
			{"聖風魔法", new List<string> {"Holy MAG", "Wind MAG"}}, //"Holy Wind MAG"
			{"聖地物理", new List<string> {"Holy ATK", "Earth ATK"}}, //"Holy Earth ATK"
			{"物理", new List<string> {"NE ATK"}},
			{"魔法", new List<string> {"MAG"}},
			{"聖炎氷物理", new List<string> {"Holy ATK", "Fire ATK", "Ice ATK"}}, //"Holy Fire Ice ATK"
			{"聖炎雷氷物理", new List<string> {"Holy ATK", "Fire ATK", "Lightning ATK", "Ice ATK"}}, //"Holy Fire Lightning Ice ATK"
			{"地聖物理", new List<string> {"Earth ATK",  "Holy ATK"}}, //"Earth Holy ATK" 
			{"炎氷雷魔法", new List<string> {"Fire MAG", "Ice MAG", "Lightning MAG"}}, //"Fire Ice Lightning MAG"
			{"ものまね", new List<string> {"Mimic"}},
			{"風毒物理", new List<string> {"Wind ATK", "Poison ATK"}}, //"Wind Poison ATK"
			{"聖氷物理", new List<string> {"Holy ATK", "Ice ATK"}}, //"Holy Ice ATK"
			{"風地魔法", new List<string> {"Earth MAG", "Wind MAG"}}, //"Earth Wind MAG"
			{"地物魔", new List<string> {"Hybrid MAG"}},
			{"毒物理", new List<string> {"Poison ATK"}},
			{"炎毒物理", new List<string> {"Fire ATK", "Poison ATK"}} //"Fire Poison ATK"
		};


		public string GetCharacterNameFromId(string altemaCharacterId)
		{
			string name = null;

			if (_characterNameMap.ContainsKey(altemaCharacterId))
			{
				name = _characterNameMap[altemaCharacterId];
			}

			return name;
		}

		public string GetRoleSummaryFromJapaneseRoleSummary(string japaneseRoleSummary)
		{
			string role = null;
			IList<string> roleParts = new List<string>();

			IList<string> japaneseRoleParts = japaneseRoleSummary.Split("/".ToCharArray()).ToList();

			foreach (string japaneseRolePart in japaneseRoleParts)
			{
				string rolePart = japaneseRolePart;
			    if (_roleSummaryMap.ContainsKey(japaneseRolePart))
			    {
			        rolePart = _roleSummaryMap[japaneseRolePart];
			    }
			    else
			    {
			        rolePart = japaneseRolePart; //seeing japanese will let us know a new term has been added and must be translated
			    }

				roleParts.Add(rolePart);
			}

			role = String.Join(" / ", roleParts);

			return role;
		}

        public IList<string> GetRolesFromJapaneseRoleSummary(string japaneseRoleSummary)
        {
            string role = null;
            IList<string> roles = new List<string>();
            IList<string> rolesPerJapaneseRolePart = new List<string>();

            IList<string> japaneseRoleParts = japaneseRoleSummary.Split("/".ToCharArray()).ToList();

            foreach (string japaneseRolePart in japaneseRoleParts)
            {
                if (_rolePartMap.ContainsKey(japaneseRolePart))
                {
                    rolesPerJapaneseRolePart = _rolePartMap[japaneseRolePart];
                }
                else
                {
                    rolesPerJapaneseRolePart.Add(japaneseRolePart); //seeing japanese will let us know a new term has been added and must be translated
                }

                roles = roles.Concat(rolesPerJapaneseRolePart).Distinct().ToList();
            }


            return roles;
        }
    }
}
