﻿#region License

// Copyright 2017 Jose Luis Rovira Martin
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

namespace Essence.Maths
{
    partial class MathUtilsTest
    {
        private readonly double[] testData3_sc = new double[]
        {
            -9.9, -0.5321491702117909, -0.4995993794887184,
            -9.8, -0.4675778018696644, -0.5019319847400192,
            -9.700000000000001, -0.5325025985642653, -0.4954863105313905,
            -9.600000000000001, -0.4678570907618177, -0.5081346815527845,
            -9.500000000000002, -0.5309998491513979, -0.487287331026566,
            -9.400000000000002, -0.4713444922468772, -0.5180408870320982,
            -9.300000000000002, -0.5246658599528169, -0.4762724916723806,
            -9.200000000000003, -0.4813519293384488, -0.5291418733145575,
            -9.100000000000003, -0.5104132951696793, -0.4666082200798341,
            -9.000000000000004, -0.4998610456296881, -0.5353661274681198,
            -8.900000000000004, -0.4885515465823427, -0.4661182045961012,
            -8.800000000000004, -0.5229409327587802, -0.5279640161512102,
            -8.700000000000005, -0.4677390574566671, -0.4827446536720937,
            -8.600000000000005, -0.5369276903450838, -0.502482860022398,
            -8.500000000000005, -0.4653412489810762, -0.5141775985837377,
            -8.400000000000006, -0.5242847697799247, -0.4709128589929102,
            -8.300000000000006, -0.4932323333308578, -0.5377466484186625,
            -8.200000000000006, -0.4858817998571301, -0.4638424766893293,
            -8.100000000000007, -0.5320393956415645, -0.5227506125578514,
            -8.000000000000007, -0.4602142143930145, -0.4998021803772038,
            -7.900000000000007, -0.5323420347477678, -0.4759737938484064,
            -7.800000000000008, -0.4896453404297859, -0.5394705526552049,
            -7.700000000000008, -0.4820141680759779, -0.4627820968226359,
            -7.600000000000009, -0.538853243389635, -0.5156312196515022,
            -7.500000000000009, -0.4607012329468338, -0.5160182501523439,
            -7.40000000000001, -0.5160655803775946, -0.4601018520794773,
            -7.30000000000001, -0.5189473278581528, -0.5392680156584583,
            -7.20000000000001, -0.4572515305828775, -0.4887439536516283,
            -7.10000000000001, -0.5360173545107733, -0.4733111966965826,
            -7.00000000000001, -0.4997047894534568, -0.5454670925469698,
            -6.900000000000011, -0.4624395077785901, -0.4732253143515223,
            -6.800000000000011, -0.5436354568235017, -0.4830698280336595,
            -6.700000000000012, -0.4915014463450973, -0.5467365748513717,
            -6.600000000000012, -0.4630695011404479, -0.4689914077118028,
            -6.500000000000012, -0.5453764552432288, -0.4816034598909524,
            -6.400000000000013, -0.4964922215459545, -0.549604555703825,
            -6.300000000000013, -0.4555454305043927, -0.4760044553530789,
            -6.200000000000014, -0.5398209788169325, -0.4676084097635153,
            -6.100000000000014, -0.5164770827951167, -0.5495022012639609,
            -6.000000000000014, -0.4469607612369302, -0.4995314678555153,
            -5.900000000000015, -0.5163306915041397, -0.4485919531698258,
            -5.800000000000015, -0.5460472837895404, -0.5298367159752168,
            -5.700000000000015, -0.4595283826476876, -0.5384589566066997,
            -5.600000000000016, -0.4700388065148483, -0.4517136246010243,
            -5.500000000000016, -0.5536840627790157, -0.4784214149253,
            -5.400000000000016, -0.5140319887019306, -0.5572337810178868,
            -5.300000000000017, -0.4404677886041, -0.5077865741552849,
            -5.200000000000017, -0.4968756558600878, -0.4388874742277434,
            -5.100000000000017, -0.5623900797330055, -0.4997821099768771,
            -5.000000000000018, -0.499191381917134, -0.5636311887040122,
            -4.900000000000018, -0.435067361787494, -0.5001609675123211,
            -4.800000000000018, -0.4967502189589286, -0.4337965816229973,
            -4.700000000000019, -0.5671454690122605, -0.4914264906010079,
            -4.60000000000002, -0.516192336949073, -0.567236682285743,
            -4.50000000000002, -0.4342729750487109, -0.5260259150535564,
            -4.40000000000002, -0.4622680164110282, -0.4383329408376895,
            -4.30000000000002, -0.5539958876665637, -0.4494411710248946,
            -4.20000000000002, -0.563198888396622, -0.5417192031633983,
            -4.100000000000021, -0.4757982570328481, -0.5736956314512114,
            -4.000000000000021, -0.4205157542469286, -0.4984260330381988,
            -3.900000000000021, -0.4752024023506688, -0.4223327102609401,
            -3.800000000000021, -0.5656187397951195, -0.4480949470128036,
            -3.700000000000021, -0.5749803498874825, -0.5419456621544693,
            -3.600000000000021, -0.4923094891110223, -0.5879532596734169,
            -3.500000000000021, -0.4152480119724453, -0.5325724350280198,
            -3.400000000000021, -0.4296494644439139, -0.4384917033638185,
            -3.300000000000021, -0.5192860849820428, -0.4056944037062549,
            -3.20000000000002, -0.593349464618596, -0.4663203469520183,
            -3.10000000000002, -0.5818158680858861, -0.56159390251134,
            -3.00000000000002, -0.4963129989673951, -0.6057207892976857,
            -2.90000000000002, -0.4101405870567258, -0.56237645022584,
            -2.80000000000002, -0.3915284435431669, -0.4674916516989254,
            -2.70000000000002, -0.4529174876167012, -0.3924939698527568,
            -2.60000000000002, -0.5499893231527011, -0.3889374961919618,
            -2.50000000000002, -0.6191817558195853, -0.4574130096417587,
            -2.40000000000002, -0.6196899649456907, -0.5549614058564097,
            -2.30000000000002, -0.55315164156072, -0.6265617097919434,
            -2.20000000000002, -0.455704612124676, -0.6362860449033243,
            -2.10000000000002, -0.3742733593781152, -0.5815641350608495,
            -2.00000000000002, -0.3434156783636982, -0.48825340607536,
            -1.90000000000002, -0.3733473178169698, -0.3944705348915388,
            -1.800000000000019, -0.4509387692675651, -0.3336329272215643,
            -1.700000000000019, -0.5491959403215495, -0.323826876003897,
            -1.600000000000019, -0.6388876835093664, -0.3654616834404755,
            -1.500000000000019, -0.6975049600820861, -0.4452611760398036,
            -1.400000000000019, -0.7135250773634135, -0.5430957835462372,
            -1.300000000000019, -0.6863332855346592, -0.6385504547270126,
            -1.200000000000019, -0.6234009185462641, -0.7154377229230616,
            -1.100000000000019, -0.5364979110968381, -0.7638066660620061,
            -1.000000000000019, -0.4382591473903735, -0.7798934003768228,
            -0.9000000000000187, -0.3397763443931581, -0.764823021273332,
            -0.8000000000000187, -0.2493413930539336, -0.7228441718963661,
            -0.7000000000000187, -0.1721364578634905, -0.6596523519045238,
            -0.6000000000000187, -0.110540207359397, -0.5810954469916683,
            -0.5000000000000188, -0.06473243286000645, -0.4923442258714636,
            -0.4000000000000188, -0.03335943266061785, -0.3974807591723776,
            -0.3000000000000188, -0.01411699800657923, -0.2994009760520658,
            -0.2000000000000188, -0.004187609161657944, -0.1999210575944718,
            -0.1000000000000188, -5.235895476125058e-4, -0.09999753262710386,
            -1.879052469178077e-14, -3.473884251368676e-42, -1.879052469178077e-14,
            0.09999999999998122, 5.235895476119156e-4, 0.09999753262706627,
            0.1999999999999812, 0.004187609161655582, 0.1999210575944343,
            0.2999999999999812, 0.01411699800657394, 0.2994009760520286,
            0.3999999999999813, 0.03335943266060852, 0.3974807591723413,
            0.4999999999999812, 0.0647324328599921, 0.492344225871429,
            0.5999999999999812, 0.1105402073593769, 0.5810954469916366,
            0.6999999999999812, 0.1721364578634644, 0.6596523519044968,
            0.7999999999999812, 0.2493413930539019, 0.722844171896346,
            0.8999999999999811, 0.3397763443931222, 0.764823021273321,
            0.9999999999999811, 0.4382591473903359, 0.7798934003768228,
            1.099999999999981, 0.5364979110968027, 0.7638066660620182,
            1.199999999999981, 0.623400918546235, 0.7154377229230856,
            1.299999999999981, 0.6863332855346415, 0.6385504547270459,
            1.399999999999981, 0.7135250773634111, 0.543095783546275,
            1.499999999999982, 0.6975049600821001, 0.4452611760398385,
            1.599999999999982, 0.6388876835093954, 0.3654616834404992,
            1.699999999999982, 0.5491959403215866, 0.3238268760039032,
            1.799999999999982, 0.4509387692676003, 0.3336329272215504,
            1.899999999999982, 0.3733473178169918, 0.394470534891508,
            1.999999999999982, 0.3434156783636982, 0.4882534060753225,
            2.099999999999982, 0.3742733593780927, 0.5815641350608193,
            2.199999999999982, 0.4557046121246392, 0.6362860449033151,
            2.299999999999982, 0.5531516415606857, 0.6265617097919601,
            2.399999999999982, 0.619689964945677, 0.5549614058564448,
            2.499999999999982, 0.6191817558196, 0.4574130096417934,
            2.599999999999982, 0.5499893231527361, 0.3889374961919756,
            2.699999999999982, 0.4529174876167352, 0.3924939698527401,
            2.799999999999983, 0.3915284435431762, 0.4674916516988885,
            2.899999999999983, 0.4101405870567031, 0.5623764502258098,
            2.999999999999983, 0.4963129989673575, 0.6057207892976856,
            3.099999999999983, 0.5818158680858645, 0.5615939025113708,
            3.199999999999983, 0.5933494646186099, 0.4663203469520538,
            3.299999999999983, 0.5192860849820798, 0.4056944037062614,
            3.399999999999983, 0.4296494644439379, 0.4384917033637896,
            3.499999999999983, 0.4152480119724308, 0.5325724350279848,
            3.599999999999983, 0.4923094891109843, 0.5879532596734145,
            3.699999999999983, 0.5749803498874648, 0.5419456621545025,
            3.799999999999983, 0.5656187397951434, 0.4480949470128325,
            3.899999999999983, 0.4752024023507045, 0.4223327102609279,
            3.999999999999984, 0.4205157542469284, 0.4984260330381609,
            4.099999999999984, 0.4757982570328122, 0.5736956314512004,
            4.199999999999983, 0.5631988883966023, 0.5417192031634294,
            4.299999999999983, 0.5539958876665898, 0.4494411710249215,
            4.399999999999983, 0.46226801641106, 0.4383329408376694,
            4.499999999999982, 0.4342729750486967, 0.5260259150535221,
            4.599999999999982, 0.5161923369490368, 0.5672366822857523,
            4.699999999999982, 0.5671454690122657, 0.4914264906010446,
            4.799999999999981, 0.4967502189589667, 0.4337965816229948,
            4.89999999999998, 0.4350673617874934, 0.5001609675122842,
            4.99999999999998, 0.499191381917097, 0.5636311887040122,
            5.09999999999998, 0.5623900797330061, 0.4997821099769144,
            5.19999999999998, 0.4968756558601252, 0.438887474227741,
            5.29999999999998, 0.4404677886040947, 0.5077865741552482,
            5.399999999999979, 0.5140319887018937, 0.5572337810178963,
            5.499999999999979, 0.5536840627790299, 0.4784214149253342,
            5.599999999999978, 0.4700388065148796, 0.4517136246010044,
            5.699999999999978, 0.4595283826476617, 0.5384589566066731,
            5.799999999999978, 0.5460472837895206, 0.5298367159752481,
            5.899999999999977, 0.5163306915041763, 0.4485919531698371,
            5.999999999999977, 0.4469607612369303, 0.4995314678554773,
            6.099999999999977, 0.5164770827950816, 0.5495022012639729,
            6.199999999999976, 0.539820978816956, 0.4676084097635437,
            6.299999999999976, 0.45554543050441, 0.4760044553530463,
            6.399999999999975, 0.4964922215459172, 0.5496045557038227,
            6.499999999999975, 0.5453764552432435, 0.4816034598909879,
            6.599999999999975, 0.4630695011404719, 0.4689914077117738,
            6.699999999999974, 0.4915014463450607, 0.5467365748513653,
            6.799999999999974, 0.5436354568235152, 0.4830698280336935,
            6.899999999999974, 0.4624395077786116, 0.4732253143514917,
            6.999999999999973, 0.4997047894534192, 0.5454670925469698,
            7.099999999999973, 0.5360173545107962, 0.4733111966966131,
            7.199999999999973, 0.4572515305828867, 0.4887439536515924,
            7.299999999999972, 0.5189473278581194, 0.5392680156584746,
            7.399999999999972, 0.5160655803776287, 0.4601018520794909,
            7.499999999999972, 0.4607012329468194, 0.5160182501523094,
            7.599999999999971, 0.5388532433896214, 0.5156312196515365,
            7.69999999999997, 0.4820141680760121, 0.4627820968226191,
            7.79999999999997, 0.4896453404297499, 0.5394705526551958,
            7.89999999999997, 0.5323420347477901, 0.4759737938484361,
            7.99999999999997, 0.4602142143930145, 0.4998021803771664,
            8.09999999999997, 0.5320393956415435, 0.5227506125578816,
            8.199999999999969, 0.485881799857165, 0.4638424766893154,
            8.299999999999969, 0.4932323333308202, 0.5377466484186559,
            8.399999999999968, 0.5242847697799533, 0.470912858992934,
            8.499999999999968, 0.4653412489810622, 0.5141775985837037,
            8.599999999999968, 0.5369276903450815, 0.5024828600224347,
            8.699999999999967, 0.4677390574566844, 0.4827446536720612,
            8.799999999999967, 0.5229409327587516, 0.5279640161512339,
            8.899999999999967, 0.4885515465823787, 0.4661182045960888,
            8.999999999999966, 0.4998610456296508, 0.5353661274681198,
            9.099999999999966, 0.5104132951697135, 0.4666082200798446,
            9.199999999999966, 0.4813519293384165, 0.529141873314537,
            9.299999999999965, 0.5246658599528433, 0.4762724916724079,
            9.399999999999965, 0.4713444922468565, 0.5180408870320656,
            9.499999999999964, 0.5309998491514124, 0.4872873310266012,
            9.599999999999964, 0.4678570907618081, 0.5081346815527471,
            9.699999999999964, 0.5325025985642707, 0.4954863105314283,
            9.799999999999963, 0.467577801869662, 0.5019319847399814,
            9.899999999999963, 0.5321491702117914, 0.4995993794887549,
            9.999999999999963, 0.4681699785848822, 0.4998986942054787,
        };
    }
}