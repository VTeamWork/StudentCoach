<%@ Page Title="" Language="C#" MasterPageFile="~/VtMasterMain.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="VteamWork.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginFormPlaceHolder" runat="server">



    <div class="card">
        <div class="body">
            <form id="sign_up" method="POST" runat="server">
                <div class="alert" ID="Alert" runat="server">
                      </div>
                <div class="msg">Register a new membership</div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">person</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="FIRST_NAME" CssClass="form-control" required="required" placeholder="First Name" autofocus=""></asp:TextBox>
                        <%--<input type="text" class="form-control" name="namesurname" placeholder="Name Surname" required autofocus>--%>
                    </div>
                </div>

                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">person</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="LAST_NAME" CssClass="form-control" required="required" placeholder="Last Name" autofocus=""></asp:TextBox>
                        <%--<input type="text" class="form-control" name="namesurname" placeholder="Name Surname" required autofocus>--%>
                    </div>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">email</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="EMAIL" CssClass="form-control" required="required" TextMode="Email" placeholder="Email" autofocus=""></asp:TextBox>
                    </div>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">lock</i>
                    </span>
                    <div class="form-line">
                        <%--<input type="password" class="form-control" name="password" minlength="6" placeholder="Password" required>--%>
                        <asp:TextBox ID="PASSWORD" runat="server" CssClass="form-control" TextMode="Password" ClientIDMode="Static" placeholder="password" required="required"></asp:TextBox>
                    </div>
                </div>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">lock</i>
                    </span>
                    <div class="form-line">
                        <%--<input type="password" class="form-control" name="confirm" minlength="6" placeholder="Confirm Password" required>--%>
                        <asp:TextBox ID="confirm" runat="server" CssClass="form-control" TextMode="Password" placeholder="confirm password" ClientIDMode="Static" required="required"></asp:TextBox>

                     
                    </div>
                </div>


                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">access_time</i>
                    </span>
                    <div class="form-line">

                        <%--<asp:DropDownList ID="USER_TYPE" runat="server" CssClass="form-control show-tick" required="required"></asp:DropDownList>--%>




                           <select ID="TimeZ" runat="server" class="form-control">
                            <option timezoneid="1" gmtadjustment="GMT-12:00" usedaylighttime="0" value="-12">(GMT-12:00) International Date Line West</option>
                            <option timezoneid="2" gmtadjustment="GMT-11:00" usedaylighttime="0" value="-11">(GMT-11:00) Midway Island, Samoa</option>
                            <option timezoneid="3" gmtadjustment="GMT-10:00" usedaylighttime="0" value="-10">(GMT-10:00) Hawaii</option>
                            <option timezoneid="4" gmtadjustment="GMT-09:00" usedaylighttime="1" value="-9">(GMT-09:00) Alaska</option>
                            <option timezoneid="5" gmtadjustment="GMT-08:00" usedaylighttime="1" value="-8">(GMT-08:00) Pacific Time (US & Canada)</option>
                            <option timezoneid="6" gmtadjustment="GMT-08:00" usedaylighttime="1" value="-8">(GMT-08:00) Tijuana, Baja California</option>
                            <option timezoneid="7" gmtadjustment="GMT-07:00" usedaylighttime="0" value="-7">(GMT-07:00) Arizona</option>
                            <option timezoneid="8" gmtadjustment="GMT-07:00" usedaylighttime="1" value="-7">(GMT-07:00) Chihuahua, La Paz, Mazatlan</option>
                            <option timezoneid="9" gmtadjustment="GMT-07:00" usedaylighttime="1" value="-7">(GMT-07:00) Mountain Time (US & Canada)</option>
                            <option timezoneid="10" gmtadjustment="GMT-06:00" usedaylighttime="0" value="-6">(GMT-06:00) Central America</option>
                            <option timezoneid="11" gmtadjustment="GMT-06:00" usedaylighttime="1" value="-6">(GMT-06:00) Central Time (US & Canada)</option>
                            <option timezoneid="12" gmtadjustment="GMT-06:00" usedaylighttime="1" value="-6">(GMT-06:00) Guadalajara, Mexico City, Monterrey</option>
                            <option timezoneid="13" gmtadjustment="GMT-06:00" usedaylighttime="0" value="-6">(GMT-06:00) Saskatchewan</option>
                            <option timezoneid="14" gmtadjustment="GMT-05:00" usedaylighttime="0" value="-5">(GMT-05:00) Bogota, Lima, Quito, Rio Branco</option>
                            <option timezoneid="15" gmtadjustment="GMT-05:00" usedaylighttime="1" value="-5">(GMT-05:00) Eastern Time (US & Canada)</option>
                            <option timezoneid="16" gmtadjustment="GMT-05:00" usedaylighttime="1" value="-5">(GMT-05:00) Indiana (East)</option>
                            <option timezoneid="17" gmtadjustment="GMT-04:00" usedaylighttime="1" value="-4">(GMT-04:00) Atlantic Time (Canada)</option>
                            <option timezoneid="18" gmtadjustment="GMT-04:00" usedaylighttime="0" value="-4">(GMT-04:00) Caracas, La Paz</option>
                            <option timezoneid="19" gmtadjustment="GMT-04:00" usedaylighttime="0" value="-4">(GMT-04:00) Manaus</option>
                            <option timezoneid="20" gmtadjustment="GMT-04:00" usedaylighttime="1" value="-4">(GMT-04:00) Santiago</option>
                            <option timezoneid="21" gmtadjustment="GMT-03:30" usedaylighttime="1" value="-3.5">(GMT-03:30) Newfoundland</option>
                            <option timezoneid="22" gmtadjustment="GMT-03:00" usedaylighttime="1" value="-3">(GMT-03:00) Brasilia</option>
                            <option timezoneid="23" gmtadjustment="GMT-03:00" usedaylighttime="0" value="-3">(GMT-03:00) Buenos Aires, Georgetown</option>
                            <option timezoneid="24" gmtadjustment="GMT-03:00" usedaylighttime="1" value="-3">(GMT-03:00) Greenland</option>
                            <option timezoneid="25" gmtadjustment="GMT-03:00" usedaylighttime="1" value="-3">(GMT-03:00) Montevideo</option>
                            <option timezoneid="26" gmtadjustment="GMT-02:00" usedaylighttime="1" value="-2">(GMT-02:00) Mid-Atlantic</option>
                            <option timezoneid="27" gmtadjustment="GMT-01:00" usedaylighttime="0" value="-1">(GMT-01:00) Cape Verde Is.</option>
                            <option timezoneid="28" gmtadjustment="GMT-01:00" usedaylighttime="1" value="-1">(GMT-01:00) Azores</option>
                            <option timezoneid="29" gmtadjustment="GMT+00:00" usedaylighttime="0" value="0">(GMT+00:00) Casablanca, Monrovia, Reykjavik</option>
                            <option timezoneid="30" gmtadjustment="GMT+00:00" usedaylighttime="1" value="0">(GMT+00:00) Greenwich Mean Time : Dublin, Edinburgh, Lisbon, London</option>
                            <option timezoneid="31" gmtadjustment="GMT+01:00" usedaylighttime="1" value="1">(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna</option>
                            <option timezoneid="32" gmtadjustment="GMT+01:00" usedaylighttime="1" value="1">(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague</option>
                            <option timezoneid="33" gmtadjustment="GMT+01:00" usedaylighttime="1" value="1">(GMT+01:00) Brussels, Copenhagen, Madrid, Paris</option>
                            <option timezoneid="34" gmtadjustment="GMT+01:00" usedaylighttime="1" value="1">(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb</option>
                            <option timezoneid="35" gmtadjustment="GMT+01:00" usedaylighttime="1" value="1">(GMT+01:00) West Central Africa</option>
                            <option timezoneid="36" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Amman</option>
                            <option timezoneid="37" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Athens, Bucharest, Istanbul</option>
                            <option timezoneid="38" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Beirut</option>
                            <option timezoneid="39" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Cairo</option>
                            <option timezoneid="40" gmtadjustment="GMT+02:00" usedaylighttime="0" value="2">(GMT+02:00) Harare, Pretoria</option>
                            <option timezoneid="41" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius</option>
                            <option timezoneid="42" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Jerusalem</option>
                            <option timezoneid="43" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Minsk</option>
                            <option timezoneid="44" gmtadjustment="GMT+02:00" usedaylighttime="1" value="2">(GMT+02:00) Windhoek</option>
                            <option timezoneid="45" gmtadjustment="GMT+03:00" usedaylighttime="0" value="3">(GMT+03:00) Kuwait, Riyadh, Baghdad</option>
                            <option timezoneid="46" gmtadjustment="GMT+03:00" usedaylighttime="1" value="3">(GMT+03:00) Moscow, St. Petersburg, Volgograd</option>
                            <option timezoneid="47" gmtadjustment="GMT+03:00" usedaylighttime="0" value="3">(GMT+03:00) Nairobi</option>
                            <option timezoneid="48" gmtadjustment="GMT+03:00" usedaylighttime="0" value="3">(GMT+03:00) Tbilisi</option>
                            <option timezoneid="49" gmtadjustment="GMT+03:30" usedaylighttime="1" value="3.5">(GMT+03:30) Tehran</option>
                            <option timezoneid="50" gmtadjustment="GMT+04:00" usedaylighttime="0" value="4">(GMT+04:00) Abu Dhabi, Muscat</option>
                            <option timezoneid="51" gmtadjustment="GMT+04:00" usedaylighttime="1" value="4">(GMT+04:00) Baku</option>
                            <option timezoneid="52" gmtadjustment="GMT+04:00" usedaylighttime="1" value="4">(GMT+04:00) Yerevan</option>
                            <option timezoneid="53" gmtadjustment="GMT+04:30" usedaylighttime="0" value="4.5">(GMT+04:30) Kabul</option>
                            <option timezoneid="54" gmtadjustment="GMT+05:00" usedaylighttime="1" value="5">(GMT+05:00) Yekaterinburg</option>
                            <option timezoneid="55" gmtadjustment="GMT+05:00" usedaylighttime="0" value="5">(GMT+05:00) Islamabad, Karachi, Tashkent</option>
                            <option timezoneid="56" gmtadjustment="GMT+05:30" usedaylighttime="0" value="5.5">(GMT+05:30) Sri Jayawardenapura</option>
                            <option timezoneid="57" gmtadjustment="GMT+05:30" usedaylighttime="0" value="5.5">(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi</option>
                            <option timezoneid="58" gmtadjustment="GMT+05:45" usedaylighttime="0" value="5.75">(GMT+05:45) Kathmandu</option>
                            <option timezoneid="59" gmtadjustment="GMT+06:00" usedaylighttime="1" value="6">(GMT+06:00) Almaty, Novosibirsk</option>
                            <option timezoneid="60" gmtadjustment="GMT+06:00" usedaylighttime="0" value="6">(GMT+06:00) Astana, Dhaka</option>
                            <option timezoneid="61" gmtadjustment="GMT+06:30" usedaylighttime="0" value="6.5">(GMT+06:30) Yangon (Rangoon)</option>
                            <option timezoneid="62" gmtadjustment="GMT+07:00" usedaylighttime="0" value="7">(GMT+07:00) Bangkok, Hanoi, Jakarta</option>
                            <option timezoneid="63" gmtadjustment="GMT+07:00" usedaylighttime="1" value="7">(GMT+07:00) Krasnoyarsk</option>
                            <option timezoneid="64" gmtadjustment="GMT+08:00" usedaylighttime="0" value="8">(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi</option>
                            <option timezoneid="65" gmtadjustment="GMT+08:00" usedaylighttime="0" value="8">(GMT+08:00) Kuala Lumpur, Singapore</option>
                            <option timezoneid="66" gmtadjustment="GMT+08:00" usedaylighttime="0" value="8">(GMT+08:00) Irkutsk, Ulaan Bataar</option>
                            <option timezoneid="67" gmtadjustment="GMT+08:00" usedaylighttime="0" value="8">(GMT+08:00) Perth</option>
                            <option timezoneid="68" gmtadjustment="GMT+08:00" usedaylighttime="0" value="8">(GMT+08:00) Taipei</option>
                            <option timezoneid="69" gmtadjustment="GMT+09:00" usedaylighttime="0" value="9">(GMT+09:00) Osaka, Sapporo, Tokyo</option>
                            <option timezoneid="70" gmtadjustment="GMT+09:00" usedaylighttime="0" value="9">(GMT+09:00) Seoul</option>
                            <option timezoneid="71" gmtadjustment="GMT+09:00" usedaylighttime="1" value="9">(GMT+09:00) Yakutsk</option>
                            <option timezoneid="72" gmtadjustment="GMT+09:30" usedaylighttime="0" value="9.5">(GMT+09:30) Adelaide</option>
                            <option timezoneid="73" gmtadjustment="GMT+09:30" usedaylighttime="0" value="9.5">(GMT+09:30) Darwin</option>
                            <option timezoneid="74" gmtadjustment="GMT+10:00" usedaylighttime="0" value="10">(GMT+10:00) Brisbane</option>
                            <option timezoneid="75" gmtadjustment="GMT+10:00" usedaylighttime="1" value="10">(GMT+10:00) Canberra, Melbourne, Sydney</option>
                            <option timezoneid="76" gmtadjustment="GMT+10:00" usedaylighttime="1" value="10">(GMT+10:00) Hobart</option>
                            <option timezoneid="77" gmtadjustment="GMT+10:00" usedaylighttime="0" value="10">(GMT+10:00) Guam, Port Moresby</option>
                            <option timezoneid="78" gmtadjustment="GMT+10:00" usedaylighttime="1" value="10">(GMT+10:00) Vladivostok</option>
                            <option timezoneid="79" gmtadjustment="GMT+11:00" usedaylighttime="1" value="11">(GMT+11:00) Magadan, Solomon Is., New Caledonia</option>
                            <option timezoneid="80" gmtadjustment="GMT+12:00" usedaylighttime="1" value="12">(GMT+12:00) Auckland, Wellington</option>
                            <option timezoneid="81" gmtadjustment="GMT+12:00" usedaylighttime="0" value="12">(GMT+12:00) Fiji, Kamchatka, Marshall Is.</option>
                            <option timezoneid="82" gmtadjustment="GMT+13:00" usedaylighttime="0" value="13">(GMT+13:00) Nuku'alofa</option>
                        </select>



                        <%--<asp:CheckBox ID="CHK_ISSTUDENT" runat="server"  CssClass="filled-in chk-col-pink" Text="Is Student"/>--%>
                    </div>
                </div>

                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">map</i>
                    </span>
                    <div class="form-line">
                        <asp:TextBox runat="server" ID="CITY" CssClass="form-control" required="required" placeholder="Nearest City"></asp:TextBox>
                        <%--<input type="text" class="form-control" name="namesurname" placeholder="Name Surname" required autofocus>--%>
                    </div>
                </div>

                <div>
                    <b>Best Phone</b>
                    <div class="input-group">
                        <span class="input-group-addon">
                            <i class="material-icons">phone</i>
                        </span>
                        <div class="form-line">

                            <asp:TextBox runat="server" ID="MOBILE_NO" CssClass="form-control" required="required" placeholder="Ex: +00 (000) 000-00-00"></asp:TextBox>
                            <%--  <input type="text" class="form-control mobile-phone-number" placeholder="Ex: +00 (000) 000-00-00">--%>
                        </div>
                    </div>
                </div>

                <div class="input-group">

                    <div class="form-line">
                        <asp:TextBox runat="server" ID="SKYPE_ID" CssClass="form-control" required="required" placeholder="Skype"></asp:TextBox>
                        <%--<input type="text" class="form-control" name="namesurname" placeholder="Name Surname" required autofocus>--%>
                    </div>
                </div>

                <b>Enrollment Date</b>
                <div class="input-group">
                    <span class="input-group-addon">
                        <i class="material-icons">date_range</i>
                    </span>
                    <div class="form-line">

                        <asp:TextBox runat="server" TextMode="Date" ID="ENROLL_DATE" CssClass="form-control date" required="required" placeholder="Ex: 30/07/2016"></asp:TextBox>

                        <%--<input type="text" class="form-control date" placeholder="Ex: 30/07/2016">--%>
                    </div>
                </div>

                <h2 class="card-inside-title">What Do You Want To Accomplish?
                </h2>
                <div class="form-group">
                    <div class="form-line">
                        <textarea id="COMMENTS" runat="server" rows="4" class="form-control no-resize" placeholder="Please type what you want... And please don't forget the ENTER key press multiple times :)"></textarea>
                    </div>
                </div>

                <div class="form-group">
                    <input type="checkbox" name="terms" id="terms" class="filled-in chk-col-red">
                    <label for="terms">I am atleast 18 years of age.</label>
                </div>

                <div class="form-group">
                    <input type="checkbox" name="agree" id="agree" class="filled-in chk-col-red">
                    <label for="agree">I read and agree to the <a href="javascript:void(0);">terms of usage</a>.</label>
                </div>





                <%--  <button class="btn btn-block btn-lg bg-pink waves-effect" type="submit">SIGN UP</button>--%>

                <asp:Button OnClick="Rigestered_Click" CssClass="btn btn-block btn-lg bg-red waves-effect" runat="server" Text="Sign UP" />

                <%--<button class="btn btn-block bg-pink waves-effect" type="submit">SIGN IN</button>--%>


                <div class="m-t-25 m-b--5 align-center">
                    <a href="Login.aspx">You already have a membership?</a>
                </div>
            </form>
        </div>
    </div>

</asp:Content>
