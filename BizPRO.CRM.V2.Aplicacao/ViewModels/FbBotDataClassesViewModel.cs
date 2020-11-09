using System.Collections.Generic;

namespace BizPRO.CRM.V2.Aplicacao.ViewModels
{
    public class FbBotDataClassesViewModel
    {
        public class BotRequestViewModel
        {
            public string @object { get; set; }
            public List<BotEntryViewModel> entry { get; set; }
        }

        public class BotEntryViewModel
        {
            public string id { get; set; }
            public long time { get; set; }
            public List<BotChangeReceivedRequestViewModel> changes { get; set; }
            public List<BotMessageReceivedRequestViewModel> messaging { get; set; }
        }

        public class BotChangeReceivedRequestViewModel
        {
            public string field { get; set; }
            public string name { get; set; }
        }

        public class BotMessageReceivedRequestViewModel
        {
            public BotUserViewModel sender { get; set; }
            public BotUserViewModel recipient { get; set; }
            public string timestamp { get; set; }
            public BotMessageViewModel message { get; set; }
            public BotPostbackViewModel postback { get; set; }
        }

        public class BotPostbackViewModel
        {
            public string payload { get; set; }
        }

        public class BotMessageResponseViewModel
        {
            public BotUserViewModel recipient { get; set; }
            public MessageResponseViewModel message { get; set; }
        }

        public class BotMessageViewModel
        {
            public string mid { get; set; }
            public List<MessageAttachmentViewModel> attachments { get; set; }
            public long seq { get; set; }
            public string text { get; set; }
            public QuickReplyViewModel quick_reply { get; set; }
        }

        public class BotUserViewModel
        {
            public string id { get; set; }
        }

        public class MessageResponseViewModel
        {
            public MessageAttachmentViewModel attachment { get; set; }
            public List<QuickReplyViewModel> quick_replies { get; set; }
            public string text { get; set; }
        }

        public class QuickReplyViewModel
        {
            public string content_type { get; set; }
            public string title { get; set; }
            public string payload { get; set; }
        }

        public class ResponseButtonsViewModel
        {
            public string type { get; set; }
            public string title { get; set; }
            public string payload { get; set; }

            public string url { get; set; }
            public string webview_height_ratio { get; set; }
        }

        public class MessageAttachmentViewModel
        {
            public string type { get; set; }
            public MessageAttachmentPayLoadViewModel payload { get; set; }
        }

        public class MessageAttachmentPayLoadViewModel
        {
            public string url { get; set; }
            public string template_type { get; set; }
            public string top_element_style { get; set; }
            public List<PayloadElementsViewModel> elements { get; set; }
            public List<ResponseButtonsViewModel> buttons { get; set; }
            public string recipient_name { get; set; }
            public string order_number { get; set; }
            public string currency { get; set; }
            public string payment_method { get; set; }
            public string order_url { get; set; }
            public string timestamp { get; set; }
            public AddressViewModel address { get; set; }
            public SummaryViewModel summary { get; set; }
        }

        public class PayloadElementsViewModel
        {
            public string title { get; set; }
            public string image_url { get; set; }
            public string subtitle { get; set; }
            public List<ResponseButtonsViewModel> buttons { get; set; }
            public string item_url { get; set; }
            public int? quantity { get; set; }
            public decimal? price { get; set; }
            public string currency { get; set; }
        }

        public class AddressViewModel
        {
            internal string street_2;

            public string street_1 { get; set; }
            public string city { get; set; }
            public string postal_code { get; set; }
            public string country { get; set; }
            public string state { get; set; }
        }

        public class SummaryViewModel
        {
            public decimal? subtotal { get; set; }
            public decimal? shipping_cost { get; set; }
            public decimal? total_tax { get; set; }
            public decimal total_cost { get; set; }
        }
    }
}