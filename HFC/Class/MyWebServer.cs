using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Data;

namespace HFC.Class
{
    class MyWebServer
    {
       static public string lat { get; set; }
       static public string lng { get; set; }
       static public string detail { get; set; }
        HttpListener server = new HttpListener();

        public static string localhost { get; set; }

        public void Start()
        {
            try
            {
                server.Prefixes.Add("http://127.0.0.1:100/");
                //  server.Prefixes.Add("http://localhost:100/");
                //server.Prefixes.Add(localhost);

                // server.Start();
                try
                {
                    server.Start(); //Throws Exception
                }
                catch (HttpListenerException ex)
                {
                    if (ex.Message.Contains("Access is denied"))
                    {
                        return;
                    }
                    else
                    {
                        throw;
                    }
                }
                Console.WriteLine("Listening...");

                while (true)
                {
                    HttpListenerContext context = server.GetContext();
                    HttpListenerResponse response = context.Response;

                    string page = context.Request.Url.ToString();

                    //page = context.Request.Url.LocalPath; ;
                    //   if (page == string.Empty)
                    if (page.Contains("nodewarning.html"))
                    {
                        TextReader tr = new StreamReader("nodewarning.txt");
                        string msg = tr.ReadToEnd();
                        // replae meta
                        msg = msg.Replace("_meta", "");
                        msg = msg.Replace("_loadfun", "");
                        msg = msg.Replace("_loadauto", "");
                        msg = updateNodeDown(msg);

                        byte[] buffer = Encoding.UTF8.GetBytes(msg);

                        response.ContentLength64 = buffer.Length;
                        Stream st = response.OutputStream;
                        st.Write(buffer, 0, buffer.Length);
                        st.Close();
                        tr.Close();
                    }
                    else if (page.Contains("node.html"))
                    {
                        TextReader tr = new StreamReader("node.txt");
                        string msg = tr.ReadToEnd();
                        msg = msg.Replace("_meta", "");
                        msg = msg.Replace("_loadfun", "");
                        msg = msg.Replace("_loadauto", "");
                        msg = updateNode(msg);
                        //msg = updateLocation(lat, lng, detail, msg);

                        byte[] buffer = Encoding.UTF8.GetBytes(msg);

                        response.ContentLength64 = buffer.Length;
                        Stream st = response.OutputStream;
                        st.Write(buffer, 0, buffer.Length);
                        st.Close();
                        tr.Close();
                    }
                    else if (page.Contains("index.html"))
                    {
                        // kiem tra loi truoc khi tra ket qua ve
                        Class.NW_Device clsnode = new Class.NW_Device();
                        DataTable dt = clsnode.NW_Device_GetStatic();
                        int checkloi = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Description"].ToString().Length > 3)
                            {
                                if (dt.Rows[i]["Description"].ToString().IndexOf(',') > 0)
                                {
                                    if (dt.Rows[i]["Value1"].ToString() == "0")
                                    {
                                        checkloi = 1;
                                    }
                                }
                            }
                        }

                        if (checkloi == 0)
                        {
                            TextReader tr = new StreamReader("node.txt");
                            string msg = tr.ReadToEnd();
                            // replae meta
                            msg = msg.Replace("_meta", "<meta http-equiv='refresh' content='120'>");
                            msg = msg.Replace("_loadfun", "onload='setInterval(function(){moveview()},10000);'");
                            msg = msg.Replace("_loadauto", "var binhthanh = {lat: 10.813224, lng: 106.700382};\n"+
                                                             "var binhthanh2 = {lat: 10.804199, lng: 106.696475};\n" +
                                                              "var binhthanh3 = {lat: 10.795778, lng: 106.710085};\n" +
                                                               "var binhthanh4 = {lat: 10.818256, lng: 106.723091};\n" +
                                                                "var govap = {lat: 10.847446, lng: 106.656770};\n" +
                                                                 "var govap2 = {lat: 10.838564, lng: 106.675493};\n" +
                                                            "var govap3 = {lat: 10.827463, lng: 106.687889};\n" +
	                                                        "var thuduc = {lat: 10.857030, lng: 106.745129};\n"+
                                                            "var thuduc2 = {lat: 10.885092, lng: 106.721829};\n" +
                                                            "var thuduc3 = {lat: 10.882226, lng: 106.777018};\n" +
                                                           " function moveview(){\n"+
	                                                       /*    
                                                           "var rand=Math.floor(Math.random() * 3 + 1);\n"+
	                                                            "if(rand==1)\n"+
	                                                           "map.setCenter(binhthanh);\n"+
	                                                            "if(rand==2)\n"+
	                                                            "map.setCenter(govap);\n"+
	                                                            "if(rand==3)\n"+
	                                                           " map.setCenter(thuduc);\n"+
	                                                                */
                                                               "if(tomap==0){\n"+
	                                                            "map.setCenter(binhthanh);\n"+
	                                                            "tomap=1;\n"+
	                                                            "}\n"+
	                                                            "else if(tomap==1){\n"+
                                                                "map.setCenter(binhthanh2);\n" +
	                                                            "tomap=2;\n"+
	                                                            "}\n"+
	                                                            "else if(tomap==2){\n"+
                                                                "map.setCenter(binhthanh3);\n" +
	                                                            "tomap=3;\n"+
	                                                            "}\n"+
                                                                "else if(tomap==3){\n" +
                                                                "map.setCenter(binhthanh4);\n" +
                                                                "tomap=4;\n" +
                                                                "}\n" +
                                                                "else if(tomap==4){\n" +
                                                                "map.setCenter(thuduc);\n" +
                                                                "tomap=5;\n" +
                                                                "}\n" +
                                                                "else if(tomap==5){\n" +
                                                                "map.setCenter(thuduc2);\n" +
                                                                "tomap=6;\n" +
                                                                "}\n" +
                                                                "else if(tomap==6){\n" +
                                                                "map.setCenter(thuduc3);\n" +
                                                                "tomap=7;\n" +
                                                                "}\n" +
                                                                 "else if(tomap==7){\n" +
                                                                "map.setCenter(govap);\n" +
                                                                "tomap=8;\n" +
                                                                "}\n" +
                                                                 "else if(tomap==8){\n" +
                                                                "map.setCenter(govap2);\n" +
                                                                "tomap=9;\n" +
                                                                "}\n" +
                                                                 "else if(tomap==9){\n" +
                                                                "map.setCenter(govap3);\n" +
                                                                "tomap=0;\n" +
                                                                "}\n" +
                                                            "};");
                            msg = updateNode(msg);
                            
                            //msg = updateLocation(lat, lng, detail, msg);

                            byte[] buffer = Encoding.UTF8.GetBytes(msg);

                            response.ContentLength64 = buffer.Length;
                            Stream st = response.OutputStream;
                            st.Write(buffer, 0, buffer.Length);
                            st.Close();
                            tr.Close();
                        }
                        else  /// loi
                        {

                            TextReader tr = new StreamReader("nodewarning.txt");
                            string msg = tr.ReadToEnd();
                            // replae meta
                            msg = msg.Replace("_meta", "<meta http-equiv='refresh' content='120'>");
                            msg = updateNodeDown(msg);

                            byte[] buffer = Encoding.UTF8.GetBytes(msg);

                            response.ContentLength64 = buffer.Length;
                            Stream st = response.OutputStream;
                            st.Write(buffer, 0, buffer.Length);
                            st.Close();
                            tr.Close();

                        }

                    }
                    else
                    {
                        string msg = "Access Deny !";

                        byte[] buffer = Encoding.UTF8.GetBytes(msg);

                        response.ContentLength64 = buffer.Length;
                        Stream st = response.OutputStream;
                        st.Write(buffer, 0, buffer.Length);
                        st.Close();
                    }

                    context.Response.Close();
                }
            }
            catch { }

        }

        public void Stop()
        {
            if (server.IsListening)
            {
                server.Stop();
            }
        }
        string updateLocation(string lat, string lng,string detail, string txt)
        {
           txt= txt.Replace("_lat", lat);
           txt= txt.Replace("_lng", lng);
           txt= txt.Replace("_detail", detail);
           return txt;
        }

        string updateNode(string txt)
        {
            NW_Node node = new NW_Node();
            DataTable dt = node.NW_Node_GetList();
            string _list = "";
            string lat="";
            string lng="";
            string link = "http://maps.google.com/mapfiles/ms/icons/green.png";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ( dt.Rows[i]["Description"].ToString().Length > 3)
                {
                    if (dt.Rows[i]["Description"].ToString().IndexOf(',') > 0)
                    {
                        if (dt.Rows[i]["NodeGroup"].ToString() == "BT")
                        {
                            link = "http://maps.google.com/mapfiles/marker_greenB.png";
                        }
                        if (dt.Rows[i]["NodeGroup"].ToString() == "GV")
                        {
                            link = "http://maps.google.com/mapfiles/marker_purpleG.png";
                        }
                        if (dt.Rows[i]["NodeGroup"].ToString() == "TD")
                        {
                            link = "http://maps.google.com/mapfiles/marker_orangeT.png";
                        }
                        if (dt.Rows[i]["NodeGroup"].ToString() == "Q2")
                        {
                            link = "http://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=2%7c5680FC%7c000000&.png%3f";
                        }
                        if (dt.Rows[i]["NodeGroup"].ToString() == "Q9")
                        {
                            link = "http://chart.googleapis.com/chart?chst=d_map_pin_letter&chld=9%7cE14E9D%7c000000&.png%3f";
                        }
                        lat = dt.Rows[i]["Description"].ToString().Substring(0, dt.Rows[i]["Description"].ToString().IndexOf(','));
                        lng = dt.Rows[i]["Description"].ToString().Substring(dt.Rows[i]["Description"].ToString().IndexOf(',')+1);
                        _list +="var info"+i.ToString()+" = new google.maps.InfoWindow({\n"+
                                                    "content: 'Node:" + dt.Rows[i]["NodeName"].ToString() + "'\n" +
                                                  "});\n" +
                            "var N"+i.ToString() +"\n"+
                            "addMarker(N"+i.ToString()+",{lat: " + lat + ", lng: " + lng + "},'" + dt.Rows[i]["NodeName"].ToString() + "', map,info"+i.ToString()+",'"+link+"') \n";
                    }
                }
            }           
          // addMarker({lat: 10.8133611, lng: 106.6974304},'aa', map)
            txt = txt.Replace("_node", _list);           
            return txt;
        }

        string updateNodeDown(string txt)
        {
            Class.NW_Device clsnode = new Class.NW_Device();
            DataTable dt = clsnode.NW_Device_GetStatic();
            string _list = "";
            string lat = "";
            string lng = "";
            string lat1 = "";
            string lng1 = "";
            string firstload = "";
            string listinfo = "";
            string path = "";
            string line="";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Description"].ToString().Length > 3)
                {
                    if (dt.Rows[i]["Description"].ToString().IndexOf(',') > 0)
                    {
                        if (dt.Rows[i]["Value1"].ToString() == "0")
                        {
                            lat = dt.Rows[i]["Description"].ToString().Substring(0, dt.Rows[i]["Description"].ToString().IndexOf(','));
                            lng = dt.Rows[i]["Description"].ToString().Substring(dt.Rows[i]["Description"].ToString().IndexOf(',') + 1);
                            _list += "" + dt.Rows[i]["NodeCode"].ToString() + ": {\n" +
                                        "center: { lat: "+lat+", lng: "+lng+" },\n"+
                                        "population: 2\n"+
                                         "} \n,";

                            firstload = "var first = new google.maps.LatLng("+lat+", "+lng+");";
                            listinfo += "var first = new google.maps.LatLng(" + lat + ", " + lng + ");\n"+                               
                                         " var coordInfoWindow = new google.maps.InfoWindow();\n"+
                                          "coordInfoWindow.setContent(createInfoWindowContent(first, map.getZoom(),'<span style=color:red><B>CẢNH BÁO MẤT TÍN HIỆU:</B></span><BR> NODE: " + dt.Rows[i]["NodeName"].ToString() + "<br>Online/Offline: " + dt.Rows[i]["Value1"].ToString() + "/" + dt.Rows[i]["Value2"].ToString() + " <br> LastSync: "+DateTime.Now.ToShortTimeString()+"'));\n" +
                                          "coordInfoWindow.setPosition(first);\n"+
                                          "coordInfoWindow.open(map);\n"+  
                                          "map.addListener('zoom_changed', function() {\n"+
                                            "coordInfoWindow.setContent(createInfoWindowContent(first, map.getZoom(),'<span style=color:red><B>CẢNH BÁO MẤT TÍN HIỆU:</B></span><BR> NODE: " + dt.Rows[i]["NodeName"].ToString() + "<br>Online/Offline: " + dt.Rows[i]["Value1"].ToString() + "/" + dt.Rows[i]["Value2"].ToString() + " <br> LastSync: " + DateTime.Now.ToShortTimeString() + "'));\n" +
                                           " coordInfoWindow.open(map);	\n"+
                                          "}); \n";
                            //kiem tra xem co Path ko
                            if (dt.Rows[i]["Path"].ToString().Length > 5)
                            {
                                string _path = dt.Rows[i]["Path"].ToString();
                                string[] catpath = _path.Split(';');
                                
                                path+="var path"+dt.Rows[i]["NodeCode"].ToString()+" = [";

                                line += "var flightPath = new google.maps.Polygon({ \n" +
                                        "paths: path" + dt.Rows[i]["NodeCode"].ToString() + ",\n" +
                                        "strokeColor: '#FF00FF',\n" +
                                        "strokeOpacity: 0.8,\n" +
                                       " strokeWeight: 2,\n" +
                                        "fillColor: '#0033CC',\n" +
                                        "fillOpacity: 0.2,\n" +
                                        "strokeWeight: 2\n"+
                                      "});\n"+
                                      "flightPath.setMap(map);\n";


                                for (int j = 0; j < catpath.Length; j++)
                                {
                                    lat1 = catpath[j].ToString().Substring(0, catpath[j].ToString().IndexOf(','));
                                    lng1 = catpath[j].ToString().Substring(catpath[j].IndexOf(',') + 1);
                                    path += "\n{lat:" + lat1 + ",lng: " + lng1 + "} ,";
                                }
                                path = path.TrimEnd(',');
                                path += "\n];\n";
                            }
                        }
                    }
                }
            }
            /*  chicago: {
                    center: {lat: _lat , lng: _lng },
                    population: 0.01
                  }
             */
            //var first = new google.maps.LatLng(41.850, -87.650);
            /*
            var coordInfoWindow = new google.maps.InfoWindow();
              coordInfoWindow.setContent(createInfoWindowContent(first, map.getZoom(),'chao'));
              coordInfoWindow.setPosition(first);
              coordInfoWindow.open(map);
  
              map.addListener('zoom_changed', function() {
                coordInfoWindow.setContent(createInfoWindowContent(first, map.getZoom(),'chào'));
                coordInfoWindow.open(map);	
              });
            */
            _list = _list.TrimEnd(',');
            txt = txt.Replace("_node", _list);
            txt = txt.Replace("_first", firstload);
            txt = txt.Replace("_addinfo", listinfo);
            if (path != "")
            {
                txt = txt.Replace("_addpath", path);
                txt = txt.Replace("_addline", line);
            }
            else
            {
                txt = txt.Replace("_addpath", "");
                txt = txt.Replace("_addline", "");
            }
            return txt;
        }


    }
}
